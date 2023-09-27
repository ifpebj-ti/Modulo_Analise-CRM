from faker import Faker
import random
import json
from datetime import datetime

def datetime_serializer(obj):
    if isinstance(obj, datetime):
        return obj.isoformat()
    raise TypeError(f"Object of type {obj.__class__.__name__} is not JSON serializable")


# Crie uma instância do Faker
fake = Faker()

# Exemplo de geração de dados para a tabela Cliente
clientes = []
for _ in range(1,100):  
    cliente = {
        "Id": _,
        "Nome": fake.first_name(),
        "Sobrenome": fake.last_name(),
        "Endereco": fake.street_address(),
        "Telefone": fake.phone_number(),
        "Email": fake.email(),
        "DataNascimento": fake.date_of_birth(minimum_age=18, maximum_age=80).strftime('%Y-%m-%d')
    }
    clientes.append(cliente)

# Exemplo de geração de dados para a tabela Produto
produtos = []
for _ in range(1,100):  
    produto = {
        "Id": _,
        "NomeProduto": fake.word(),
        "Descricao": fake.sentence(nb_words=6),
        "Categoria": fake.word(),
        "PrecoVenda": round(random.uniform(10, 1000), 2),
        "QuantidadeEstoque": random.randint(1, 100),
        "DataValidade": fake.date_between(start_date='-30d', end_date='+180d').strftime('%Y-%m-%d'),
        "Fornecedor": fake.company()
    }
    produtos.append(produto)

# Exemplo de geração de dados para a tabela Venda
vendas = []
for _ in range(200):  
    venda = {
        "Id_venda": _,
        "DataHoraVenda": fake.date_time_this_decade(),
        "ID_Cliente": random.randint(1, 100),  # ID de cliente aleatório
        "TotalVenda": round(random.uniform(10, 1000), 2)
    }
    vendas.append(venda)



# Suponhamos que você tenha as listas 'clientes', 'produtos' e 'vendas' com os dados

# Crie um dicionário para agrupar todas as listas
data = {
    "clientes": clientes,
    "produtos": produtos,
    "vendas": vendas
    # Adicione outros dados de tabelas aqui, se necessário
}

# Escreva os dados em um arquivo JSON
with open('dados.json', 'w') as json_file:
    json.dump(data, json_file, default=datetime_serializer, indent=4)

print("Dados foram escritos no arquivo 'dados.json'")
