## Exercício `Ursos`

Faça um programa para análise de dados coletados de ursos selvagens.

Para cada urso, receba o peso (kg) e o sexo (M/F). Finalize a coleta ao receber um peso zero, negativo ou acima de 250kg.

Para cada sexo, classifique os ursos em 5 categorias de peso:

| Categoria    | Intervalo    |
| ------------ | ------------ |
| Muito Leve   | `]0, 50]`    |
| Leve         | `]50, 100]`  |
| Médio        | `]100, 150]` |
| Pesado       | `]150, 200]` |
| Muito Pesado | `]200, 250]` |

Exiba:

- o sexo e o peso do urso mais pesado;
- a média de peso por sexo;
- uma tabela de distribuição de frequência;
- histogramas para ambos os sexos.

Exemplo de tabela de distribuição de frequências:

| Categoria | Ursos | Ursos (%) | Machos | Machos (%) | Fêmeas | Fêmeas (%) |
| --------- | ----- | --------- | ------ | ---------- | ------ | ---------- |
| ML        | 1     | 10%       | 0      | 0%         | 1      | 20%        |
| L         | 2     | 20%       | 1      | 20%        | 1      | 20%        |
| M         | 3     | 30%       | 1      | 20%        | 2      | 40%        |
| P         | 3     | 30%       | 2      | 40%        | 1      | 20%        |
| MP        | 1     | 20%       | 1      | 20%        | 0      | 0%         |
| Total     | 10    | 100%      | 5      | 50%        | 5      | 50%        |

Exemplo de histogramas:

```
----- Ursos Machos -----
   +...10...20...30...40...50...60...70...80...90..100
ML |
L  |**********
M  |**********
P  |********************
MP |**********

----- Ursos Fêmeas -----
   +...10...20...30...40...50...60...70...80...90..100
ML |**********
L  |**********
M  |********************
P  |**********
MP |

----- Ursos (todos) -----
   +...10...20...30...40...50...60...70...80...90..100
ML |*****
L  |**********
M  |***************
P  |***************
MP |**********
```
### _Scrennshot_

![Tela do programa](tela.png)

###_Donwload_

Baixe o arquivo abaixo. Descompacte na pasta desejada.

[📁 Download de arquivo .zip](dist/ursos.zip)

Execute utilizando o comando: 
```
dotnet ursos.dll
```

Ou, se você estiver no Windows, pode dar um duplo-clique no ícone do programa.
