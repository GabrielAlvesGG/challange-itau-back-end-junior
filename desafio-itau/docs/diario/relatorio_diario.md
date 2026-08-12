Desafio Itaú diário de desenvolvimento. 

  

11/08/2026 

  

1- Criar a API.  

  

	- Dentro da criação da API foi algo comum na minha rotina de desenvolvimento; consegui aprender a executar  

	Essa tarefa, com maestria, utilizando o comando "dotnet new webapi -n nome_do_projeto", fez com que a 

	Estrutura inicial de uma API com o ASP.NET foi criada com sucesso. 

  

2- Confiança 

  

	- Com o Swagger, estou tendo um pouco de problemas para implementá-lo dentro da aplicação; o meu maior  

	Desafio durante a implementação do Swagger está sendo as referências de bibliotecas. Tentei seguir algumas 

	Documentações, não reparando corretamente no que foi implementado com os comandos, acabei ficando com dois. 

	Geradores de documentação da API: o OpenAPI e o Swagger.  

  

	Está acontecendo uma divergência com os dois geradores de documento pelo motivo de o SwashBuckle ser responsável 

	Por percorrer o projeto e documentar quais são os endpoints que contém no projeto, está se confundindo com 

	as versões dos projetos. Ele foi instalado por mim por meio de uma linha de comando. 

  

	Agora a forma de conseguir fazer funcionar a implementação do Swagger é retirando o OpenAPI da referência do 

	Projeto para que não tenha mais esse problema dentro da aplicação no momento da construção da DLL da API. 

  

	Mais um desafio está acontecendo, que é o comando de remoção da biblioteca pelo CLI. Estou tentando buscar 

	Uma forma para conseguir excluir essa referência direto pelo CLI sem utilizar nenhuma IA. Porém, acho que 

	Vou apelar pelo bom NuGet para conseguir fazer a remoção da referência da biblioteca OpenApi que está  

	causando conflito no meu projeto. 

  

	Ao fazer a retirada das dependências do OpenAPI e também retirar a chamada do método que estava no programa, 

	Funcionou corretamente e não explodiu nenhum erro. 

  

	Falta agora somente um método dentro do programa que é responsável por renderizar a interface do Swagger no 

	arquivo program.cs. Então implementei as duas linhas que faltavam: "app. Use Swagger() e app. Use SwaggerUI(). 

  

	Depois desses desafios, também foi implementado o Swagger. 

  
3 - Próximos passos 

	Os próximos passos são limpar todo o excesso que ficou quando foi criada a API, montar uma arquitetura que 

	Seja compatível com esse tipo de projeto. 


Problemas do Dia

	- TypeLoadException : É um tipo de exception que pode acabar confundindo o que está realmente causando um 
	problema dentro do sistema. Nesse caso foi a questão de duas bibliotecas a OpenApi e o Swagger estavam 
	entrando em conflito por conta que o SwashBuckle não sabia qual é a versão correta

	- Tópicos dos problemas 

		# TypeLoadException
		# OpenApi
		# Swagger

  