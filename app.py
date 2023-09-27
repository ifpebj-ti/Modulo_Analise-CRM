from flask import Flask, jsonify, request
import json
import random
from functools import wraps
import json
from flask_cors import CORS
from datetime import datetime


app = Flask(__name__)
CORS(app)


@app.before_first_request
def carregar_dados():
    global dados
    with open('dados.json', 'r', encoding='utf-8') as f:
        dados = json.load(f)


@app.route('/api/bar_chart_data')
def bar_chart_data():
    mes = int(request.args.get('mes', datetime.now().month))
    
    vendas_do_mes = [venda for venda in dados['vendas'] if datetime.strptime(venda["DataHoraVenda"], "%Y-%m-%dT%H:%M:%S").month == mes]

    vendas_por_cliente = {}
    for venda in vendas_do_mes:
        cliente_id = venda["ID_Cliente"]
        if cliente_id not in vendas_por_cliente:
            vendas_por_cliente[cliente_id] = 0
        vendas_por_cliente[cliente_id] += venda["TotalVenda"]

    top_clientes = sorted(vendas_por_cliente.items(), key=lambda x: x[1], reverse=True)[:5]

    labels = [str(cliente_id) for cliente_id, _ in top_clientes]
    labels2 = []
    for c in labels:
        labels2.append(f"Nome: {dados['clientes'][int(c)-1]['Nome']} - Id: {dados['clientes'][int(c)-1]['Id']}")


    data = [round(valor, 2) for _, valor in top_clientes]

    return jsonify({"data": data, "labels": labels2})

if __name__ == '__main__':
    app.run(debug=True)