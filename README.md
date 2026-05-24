# AWS CodePipeline Demo - .NET 10 + Elastic Beanstalk

## Rotas

- `/` retorna uma mensagem básica e aponta para a documentação.
- `/api/hello` retorna `Hello World`.
- `/health` retorna status simples para teste/health check.
- `/scalar/v1` abre a UI do Scalar.
- `/openapi/v1.json` expõe o documento OpenAPI.

## Rodando localmente

```bash
/home/fernando/.dotnet/dotnet run
```

Depois acesse a URL exibida no terminal.

## Fluxo de deploy

1. Subir este projeto para um repositório GitHub.
2. Criar uma aplicação e um ambiente no Elastic Beanstalk.
3. Usar a plataforma `64bit Amazon Linux 2023 running .NET 10`.
4. Criar um CodePipeline com source no GitHub.
5. Criar um CodeBuild usando buildspec do repositório: `./buildspec.yml`.
6. No estágio de deploy, selecionar Elastic Beanstalk e apontar para a aplicação/ambiente criados.
7. A cada push na branch configurada, o pipeline deve restaurar, compilar, publicar e enviar o pacote para o Elastic Beanstalk.

## Configuração importante na AWS

No CodeBuild, use uma imagem gerenciada que suporte .NET 10 e mantenha no `buildspec.yml`:

```yaml
runtime-versions:
  dotnet: 10.0
```

No Elastic Beanstalk, selecione a plataforma Linux de .NET 10. Os docs atuais da AWS listam `.NET 10 on AL2023` para Elastic Beanstalk e `dotnet: 10.0` para CodeBuild:

- https://docs.aws.amazon.com/elasticbeanstalk/latest/platforms/platforms-supported.html
- https://docs.aws.amazon.com/codebuild/latest/userguide/runtime-versions.html

## Arquivos usados pela pipeline

- `buildspec.yml`: comandos executados pelo CodeBuild.
- `Procfile`: comando usado pelo Elastic Beanstalk para iniciar a aplicação publicada.
