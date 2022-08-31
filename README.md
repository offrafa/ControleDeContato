# Controle De Contato

## Para utilizar o sistema corretamente precisará realizar os seguintes passos:

Abrir o arquivo appsettings.json: 

![inicio](https://user-images.githubusercontent.com/91328590/187377046-a76b25e0-f961-4877-a82e-b3c362f08ce9.png)


Adicionar a configuração do SMTP e conexão com SQL: 

![string](https://user-images.githubusercontent.com/91328590/187379791-b4be2ed8-371f-4ed4-b5c2-970c57d25ac1.png)


Exemplo de conexão:

Integrated `Security=SSPI`;Persist Security Info=False;Initial `Catalog=SistemaDeContato`;`Data Source=LAPTOP-2R8BRF4I\\SQLEXPRESS`

Para fazer a conexão tem que passa o tipo de segurança, nome do banco de dados e a máquina.

Criar Banco de dados:

![Banco](https://user-images.githubusercontent.com/91328590/187383686-b41af045-620c-4d0f-9de7-81b2f8a5a9dd.png)

Após já ter criado banco de dados feito as devidas configurações

No Console do Gerenciador de Pacotes do visual studio 
 
![config](https://user-images.githubusercontent.com/91328590/187385342-b6bf885d-dc93-400a-b4e0-8c270ef1c1f8.png)

Digite o seguinte comando

## Update-Database
