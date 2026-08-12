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

  12/08/2026 

4 - Criando uma arquitetura de pastas

	- O primeiro ponto, é conseguir achar uma arquitetura de pastas que faça sentido com a realidade do projeto
	para não ocorrer confusões durante o desenvolvimento do projeto. Estou percebendo que uma boa é organizar as
	pastas em algo voltado para Services, infrastrutura e domain. 

	 Dessa forma o código fica mais organizado, não irei criar bibliotecas dela para ser uma clear archicteture,
	porém ira ficar organizado por essas funcionalidades. Sendo assim, criar o bussines para caso de uso, models
	como se fosse o domain e data para as coisas que irão ficar armazenada no banco sendo algo parecido com 
	infrastruture.

	 Não esquecendo também da pasta controller que vai ser responsável pelos end-points. Ficando dessa forma a 
	arquitetura de pasta do projeto:

	desafio-itau
	      |
		  |- Controller (Cuida dos end-points.)
		  |- Bussines (Onde será aplicado validações e regras de negócios.)
		  |- Models (Ficara armazenado as entidades.)
		  |- Data (Armazenamento em memória.)

5 - Criando end-points da api

	- Vamos começar a implementar o end-point que recebe transações, ele vai ser um tipo de requisição HTTP e 
	deve ser chamado de "/transacao", recebendo um JSON com dois valores como parâmetro "valor: double" e "dataHora: DateTime" 

	 Primeira coisa que irei fazer é criar uma classe controller para esse e end-point. Quando criei a nova 
	classe de controller estou percebendo que a herança para a classe controller que criei está sem referência
	de namespace, então vou ter que verificar qual é o motivo disso.

	 Problema resolvido e classe foi criada o problema era que o namespace e o nome da biblioteca controller
	estava sendo herdada estava dando conflito por terem nomes iguais. Desmembro melhor esse problema no 
	problemas do dia

	 O primeiro end-point foi criado com os dois parâmetros que é exigido no desafio "valor" e "dataHora" o
	o valor acabei colocando o tipo como double para conseguir aceitar ponto flutuante e o parâmetro de 
	dataHora coloquei DateTime para implementar o horário da forma padrão.Dessa forma, agora vou começar a
	implementar as regras que estão descrita no desafio.

	 A primeira regra que implementei foi sobre os dois parâmetros virem null dentro da requisição, quando
	eles vem null eu devolvo a requisição com um BadRequest, retornando uma mensagem "É necessário que os campos
	'valor' e 'dataHora' venham preenchidos."

	 Segunda regra a ser implementada é sobre não ser no futuro, precisa validar se o parâmetro de periodo está no
	 momento presente ou passado. Validação foi implementada sem muita dificuldade, apenas um if foi o suficiente.

	 Terceiro ponto que foi ajustado é a questão do end-point receber os valores por meio de json dentro do corpo da
	 requisição.

	 Quarto ponto ajuste das respostas da requisição no caso de dar erro ao invés de BadRequest é interessante 
	 implementar uma resposta que faça mais sentido como é o que está no desafio o 422 Unprocessable Entity e 
	 uma descrição do motivo de não poder ser processado. Foi ajustado também quando a transação foi aceita para
	 201 Created. E por último o BadRequest no caso de não ter nenhum parâmetro para conseguir processar retornando
	 o erro 400 BadRequest.







Problemas do dia 

	- Criação da classe controller: Não contem referência using namespace.

	 O problema não era o que suspeitava de não conter referência de namespace o problema estava sendo que o nome
	do namespace era o mesmo da classe que iria herdar a controller. Então nessa caso o meu namespace estava como
	"desafio_itau.Controller" e a classe que seria herdade para conseguir fazer a contrução do controller se chama
	"Controller" essa repetição de Controller foi o que estava ocasionando o problema, a resposta generica de erro
	que foi retornada para eu começar a fazer uma analise sobre foi essa aqui:
	
		"'Controller' is a namespace but is used like a type"
	
	 Solução: Alterando  o namespace de "desafio_itau.Controller" para "desafio_itau.ControllerApi" já resolveu esse problema

	-  Quando escolho para rodar o projeto em https, está acontecendo um problema com o response do servidor para o
	cliente com essa seguinte mensagem "Failed to fetch" e fala que as possíveis razões são CORS Network Failure e
	URL scheme must be "http" or "https" for CORS request.

	 Pelo que consegui compreender do problema é que eu estava utilizando a url do próprio projeto para chamar ele mesmo,
	dessa maneira fazendo com que o CORS fosse ativado e não permitindo que a requisição fosse chamada corretamente. Notei
	essa mudança somente no momento em que visualizei um terminal que é onde ficam as urls da API mostrando a API que deve
	ser consumida e a API padrão do próprio projeto. O motivo desse erro foi eu estar afim de usar o swagger para fazer o
	teste. Irei começar a utilizar o postman para fazer os testes do meu projeto como pede o desafio o problema atual foi
	a falta de atenção junto ao conceito de CORS que estava faltando da minha parte, o erro que estava sempre retornando
	era esse: 

	 "	Failed to fetch.
		Possible Reasons:

		CORS
		Network Failure
		URL scheme must be "http" or "https" for CORS request.
	 "

	  Solução: Escolher a url correta em vez de escolher a própria url da API que não é para ser utilizada ou usar o POSTMAN
	  como é sugerido no desafio.

	 