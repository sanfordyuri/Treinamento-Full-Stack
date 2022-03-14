# rxcrud-api-template <img alt="rxcrud" height="20" src="https://github.com/rxcrud/rxcrud-api-template/blob/main/rxcrud.png">
Template de aplicação para criação de projetos (<a href="https://rxcrud-api-template.herokuapp.com/swagger/index.html" target="_blank">Acessar</a>)

![API ](https://img.shields.io/badge/API-C%23%20%2B%20.Net%20Core-blue) [![rxcrud](https://github.com/rxcrud/rxcrud-api-template/actions/workflows/rxcrud.yml/badge.svg)](https://github.com/rxcrud/rxcrud-api-template/actions/workflows/rxcrud.yml)

## Scripts Disponíveis

No console do gerenciador de pacotes, você pode executar:

Gerar dados para relatório de cobertura:

```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutput=CoverageData/ /p:CoverletOutputFormat=opencover
```

Gerar relatório de cobertura: (Lembrar de verificar se o caminho do ReportGenerator
e do projeto estão corretos)

```bash
dotnet %USERPROFILE%\.nuget\packages\reportgenerator\5.0.4\tools\net6.0\ReportGenerator.dll "-reports:.\RXCrud.NUnitTest\CoverageData\coverage.opencover.xml" "-targetdir:.\RXCrud.NUnitTest\CoverageReport" -reporttypes:Html
```

Acessar relatório de cobertura:

```bash
.\RXCrud.NUnitTest\CoverageReport\index.html
```

## ⚠️ Licença
`rxcrud-api-template` é um template de aplicação para criação de projetos licenciado sob a [MIT License](https://github.com/rxcrud/rxcrud-api-template/blob/main/LICENSE).