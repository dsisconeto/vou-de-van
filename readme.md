
### Nova Migration

Dentro do projeto Database

```shell
  dotnet ef --startup-project ..\..\App\Web\Services  migrations add CreateNomeTabelaNoPluralTable
```

### Rorando novas migra��es

```shell
  dotnet ef --startup-project ..\..\App\Web\Services  database update
```


