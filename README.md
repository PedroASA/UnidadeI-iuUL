# Semana 1

## Estrutura de Arquivos desse "branch"

```
.
├── Aquecimento.sln
├── Ex1
│   ├── Ex1.csproj
│   ├── Piramide.cs
│   ├── Program.cs
│   └── Properties
│       └── launchSettings.json
├── Ex2
│   ├── Ex2.csproj
│   ├── Program.cs
│   └── Vertice.cs
├── Ex3
│   ├── Ex3.csproj
│   ├── Program.cs
│   └── Triangulo.cs
├── Ex4
│   ├── Ex4.csproj
│   ├── Poligono.cs
│   └── Program.cs
├── Ex5
│   ├── Ex5.csproj
│   ├── Intervalo.cs
│   └── Program.cs
├── Ex6
│   ├── Ex6.csproj
│   ├── ListaIntervalo.cs
│   └── Program.cs
├── Ex7
│   ├── Cliente.cs
│   ├── Ex7.csproj
│   ├── Program.cs
│   ├── Properties
│   │   └── launchSettings.json
│   ├── cliente1-out.txt
│   ├── cliente1.txt
│   ├── cliente2-out.txt
│   └── cliente2.txt
└── README.md
```

O repositório é constituído por uma solução do Visual Studio (**Aquecimento.sln**), e sete projetos (um para cada exercício resolvido), todos associados a essa solução.

**Obs:** 
* No projeto __Ex1__, é preciso passar um valor inteiro por linha de comando, o que é feito modificando o campo _"CommandLineArgs"_ do arquivo __Ex1/Properties/launchSettings.json__

* No projeto __Ex7__, é possível redirecionar o _"input"_ e _"output"_ do programa, o que é feito modificando o campo _"CommandLineArgs"_ do arquivo __Ex7/Properties/launchSettings.json__ para algo como _"< input.txt > output.txt"_. Caso seja necessário interagir com o console, deve-se apagar os valores do campo _"CommandLineArgs"_. Os arquivos __cliente1.txt__ e __cliente-2.txt__ são arquivos com arquivos testes, com suas respectivas saídas (__cliente1-out.txt__ e __cliente-2-out.txt__).
