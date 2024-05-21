# TektokLabs Hexagonal Api (Prueba)

Este proyecto implementa una API REST en .NET 8 utilizando la arquitectura Hexagonal (Ports and Adapters), principios SOLID, y patrones de diseño como CQRS y Mediator. 
Además, se ha utilizado TDD para el desarrollo de la solución.

## Arquitectura y Patrones

- **Hexagonal Architecture**: Separa la lógica de negocio del acceso a datos y otros servicios externos, facilitando la prueba y la evolución de la aplicación.
- **CQRS**: Separa las operaciones de lectura y escritura para simplificar la lógica de la aplicación. Command y Queries.
- **Mediator**: Centraliza las solicitudes de CQRS para evitar acoplamiento directo entre componentes.
- **Repository Pattern**: Proporciona una abstracción sobre la capa de datos para facilitar la prueba y el mantenimiento.

## Principios SOLID

1. **Single Responsibility Principle (SRP)**: Cada clase tiene una única responsabilidad. Por ejemplo, CreateProductCommandHandler maneja exclusivamente la creación de productos.
2. **Open/Closed Principle (OCP)**: Las clases están abiertas para extensión pero cerradas para modificación. Se pueden agregar nuevas validaciones creando nuevas clases sin modificar las existentes.
3. **Liskov Substitution Principle (LSP)**: Las implementaciones de IProductRepository pueden sustituirse sin alterar el comportamiento del programa.
4. **Interface Segregation Principle (ISP)**: IProductRepository define únicamente las operaciones necesarias para gestionar productos, evitando métodos innecesarios.
5. **Dependency Inversion Principle (DIP)**: Se inyectan dependencias como IProductRepository en los controladores y manejadores de comandos, siguiendo el principio de inversión de dependencias.

## Explicación de Patrones y Herramientas
### Mediator Pattern

El patrón Mediator se utiliza para reducir las dependencias entre objetos al mediar la comunicación entre ellos. En este proyecto, se utiliza el paquete MediatR para implementar el patrón Mediator, lo que facilita la separación de las responsabilidades y el manejo de comandos y consultas (CQRS).

### Repository Pattern
El patrón Repository proporciona una abstracción sobre la capa de acceso a datos, permitiendo que la lógica de negocio interactúe con los datos sin preocuparse por los detalles de la implementación de la persistencia. Esto facilita el mantenimiento y la prueba de la aplicación.

### FluentValidation
FluentValidation es una biblioteca .NET para la validación de objetos que utiliza una sintaxis fluida y expresiva. Permite definir reglas de validación de manera sencilla y clara.

## Características Adicionales
### Logging
Se loguea el tiempo de respuesta de cada request en un archivo de texto plano.

### Caching
Se mantiene en caché (5 minutos) un diccionario de estados del producto.

## Configuración del Proyecto
### Prerrequisitos
- .NET 8.0

### Pasos para Levantar el Proyecto
1. Clonar el repositorio https://github.com/usuario/hexagonal-api.git
2. Restaurar los paquetes
3. Abrir el proyecto en VS 2022