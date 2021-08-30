## Çiçek Sepeti Case Study - Basket Demo

## Project Subject
Bir e-ticaret sitesi için ürün ekleme, listeleme vb. endpointlerin zaten daha önceden yazıldığını varsayılarak sadece sepete ürün ekleme endpointi barındıran bir ASPNET Core API yazılması.
 
## Project Tiers
- CicekSepetiStudyCase.API
- CicekSepetiStudyCase.Domain
- CicekSepetiStudyCase.Infrastructure
- CicekSepetiStudyCase.Manager
- CicekSepetiStudyCase.Shared

## Project Requirements and Description
- Project needs .Net 5 and Docker
- BasketId can be any id. It can be associated with the member in real projects.

## Project Run and Debug
- The application is Dockerized. It can stand up from the Docker Compose file.
- "docker-compose up -d"Run this code with powershell project root folder
- CicekSepetiStudyCase.API project should be selected as startup project.
- After the container is up in Docker, the database is created automatically when the project is run. When the database was created, sample products were added with seed data.
- API swagger document after running with Docker: https://localhost:44352/swagger 

## Used Technologies and Patterns
- .Net 5
- Docker
- MongoDB (for products)
- Redis (for basket)
- Fluent Validation
- AutoMapper 
- Repository Pattern
- Options Pattern
- Swagger
 
## Sample Requests:

#Product
- Get 
 ​
​/api​/product 
​/api​/product​/{id}

#Basket
- Get

/api/basket/{id}

- Post

​/api​/basket​/product

{
  "id": "testBasketId",
  "item": {
    "productId": "testProductId",
    "quantity": 2
  }
}

- Delete
​
​/api​/basket​/{id}