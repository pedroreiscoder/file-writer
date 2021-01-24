# file-writer

FileWriter é um gerador de arquivos que obtém os textos gerados pelo site https://lerolero.com/ realiza uma chamada para o site https://mothereff.in/byte-counter para obter o total de bytes do texto e escreve em um arquivo de acordo com parâmetros passados pelo usuário, como o caminho para escrita, o tamanho máximo do buffer e o tamanho do arquivo.

# Requisitos

.NET Core SDK 3.1  
Chrome versão 88.0.4324

# Instalação

Faça um clone do repositório para sua máquina, abra a solução com algum editor de texto ou IDE e build a solução, certifique que seu chrome esteja na versão acima e abra o executável do projeto na pasta bin/Debug/netcoreapp3.1

# Como usar

Ao abrir o executável do projeto o programa irá solicitar o caminho para escrita do arquivo, informe o mesmo no formato do exemplo: C:\arquivos\trabalho (sem a contrabarra \ no final).

Se quiser alterar o tamanho padrão do arquivo (100MB) digite 's' e após isso informe o valor como um número inteiro positivo.

Se quiser alterar o tamanho máximo do buffer (1MB) digite 's' e após isso informe o valor como um número inteiro positivo.

Se não quiser alterar algum dos tamanhos apenas digite 'n'.

Feito isso o programa irá gerar o arquivo no diretório informado e apresentará um pequeno relatório contendo informações sobre o arquivo gerado.

# Disclaimer

Os sites https://lerolero.com/ e https://mothereff.in/byte-counter geram seu conteúdo de forma dinâmica, através do JavaScript.

Devido a isso não foi possível obter os textos com um web crawler tradicional que apenas lê o código-fonte da página, sendo necessário um navegador para carregar a página antes da busca pelo crawler.

A ferramenta escolhida para esse procedimento foi o Selenium WebDriver e por isso existe a dependência do Chrome.

Caso o avaliador desse teste saiba de uma solução sem a dependência de um navegador ficaria muito feliz em conhecer :smiley:
