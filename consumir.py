import requests

response = requests.get('http://localhost:5000/api/bar_chart_data', params={'mes': 8})

if response.status_code == 200:
    data = response.json()
    print(data)
else:
    print('Erro:', response.status_code)
    print(response.text)