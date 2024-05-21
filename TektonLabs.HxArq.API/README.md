# TektokLabs Hexagonal Api (Prueba)

Este proyecto implementa una API REST en .NET 8 utilizando la arquitectura Hexagonal (Ports and Adapters), principios SOLID, y patrones de dise�o como CQRS y Mediator. 
Adem�s, se ha utilizado TDD para el desarrollo de la soluci�n.

## Arquitectura y Patrones

- **Hexagonal Architecture**: Separa la l�gica de negocio del acceso a datos y otros servicios externos, facilitando la prueba y la evoluci�n de la aplicaci�n.
- **CQRS**: Separa las operaciones de lectura y escritura para simplificar la l�gica de la aplicaci�n. Command y Queries.
- **Mediator**: Centraliza las solicitudes de CQRS para evitar acoplamiento directo entre componentes.
- **Repository Pattern**: Proporciona una abstracci�n sobre la capa de datos para facilitar la prueba y el mantenimiento.

## Principios SOLID

1. **Single Responsibility Principle (SRP)**: Cada clase tiene una �nica responsabilidad. Por ejemplo, CreateProductCommandHandler maneja exclusivamente la creaci�n de productos.
2. **Open/Closed Principle (OCP)**: Las clases est�n abiertas para extensi�n pero cerradas para modificaci�n. Se pueden agregar nuevas validaciones creando nuevas clases sin modificar las existentes.
3. **Liskov Substitution Principle (LSP)**: Las implementaciones de IProductRepository pueden sustituirse sin alterar el comportamiento del programa.
4. **Interface Segregation Principle (ISP)**: IProductRepository define �nicamente las operaciones necesarias para gestionar productos, evitando m�todos innecesarios.
5. **Dependency Inversion Principle (DIP)**: Se inyectan dependencias como IProductRepository en los controladores y manejadores de comandos, siguiendo el principio de inversi�n de dependencias.

## Explicaci�n de Patrones y Herramientas
### Mediator Pattern

El patr�n Mediator se utiliza para reducir las dependencias entre objetos al mediar la comunicaci�n entre ellos. En este proyecto, se utiliza el paquete MediatR para implementar el patr�n Mediator, lo que facilita la separaci�n de las responsabilidades y el manejo de comandos y consultas (CQRS).

### Repository Pattern
El patr�n Repository proporciona una abstracci�n sobre la capa de acceso a datos, permitiendo que la l�gica de negocio interact�e con los datos sin preocuparse por los detalles de la implementaci�n de la persistencia. Esto facilita el mantenimiento y la prueba de la aplicaci�n.

### FluentValidation
FluentValidation es una biblioteca .NET para la validaci�n de objetos que utiliza una sintaxis fluida y expresiva. Permite definir reglas de validaci�n de manera sencilla y clara.

## Caracter�sticas Adicionales
### Logging
Se loguea el tiempo de respuesta de cada request en un archivo de texto plano.

### Caching
Se mantiene en cach� (5 minutos) un diccionario de estados del producto.

## Configuraci�n del Proyecto
### Prerrequisitos
- .NET 8.0

### Pasos para Levantar el Proyecto
1. Clonar el repositorio https://github.com/usuario/hexagonal-api.git
2. Restaurar los paquetes
3. Abrir el proyecto en VS 2022