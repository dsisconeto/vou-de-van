
### Nova Migration

Dentro do projeto Database

```shell
  dotnet ef --startup-project ..\..\App\Web\AdminPanel  migrations add CreateNomeTabelaNoPluralTable
```

### Rorando novas migra��es

```shell
  dotnet ef --startup-project ..\..\App\Web\AdminPanel  database update
```


