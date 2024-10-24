# Aplicación de Registro de Estudiantes

Esta aplicación permite a los estudiantes registrarse en materias como parte de un programa basado en créditos. A continuación, se presenta un resumen de las principales características y requerimientos implementados en el sistema.

## Características

1. **Programa de Créditos**: Cada estudiante sigue un programa basado en créditos, donde las materias se asignan con un valor específico de créditos.

2. **Materias Disponibles**: Hay un total de 10 materias disponibles en el sistema, cada una equivalente a 3 créditos.

3. **Selección de Materias**: Los estudiantes pueden seleccionar un máximo de 3 materias durante su registro.

4. **Profesores**: Existen 5 profesores en el sistema, y cada profesor está asignado para dictar 2 materias.

5. **Restricciones**: Un estudiante no puede tener al mismo profesor en más de una materia.

6. **Compañeros en Línea**: Cada estudiante puede ver los nombres de otros estudiantes inscritos en las mismas materias.

7. **Información de Compañeros**: Los estudiantes solo podrán ver los nombres de los compañeros con los que compartirán clase, protegiendo así la privacidad de quienes no están en las mismas materias.

## Tecnologías Utilizadas

- **Backend**: .NET
- **Frontend**: Angular
- **Base de Datos**: MySQL
  
Instrucciones de Configuración
Clonar el repositorio:
```
git clone https://github.com/usuario/registro-estudiantes.git
cd registro-estudiantes
```
Instalar dependencias:
```
# Dependencias del Backend
cd backend
dotnet restore
```

# Dependencias del Frontend
```
cd ../frontend/student-registration-app
npm i
```

Ejecutar la aplicación:

# Backend
Configurar la base de datos a utilizar, para ello en los archivos "Backend/src/StudentRegistrationApp.Presentation/appsettings.json/appsettings.Development.json" 
y "Backend/src/StudentRegistrationApp.Infrastructure/Adapters/Out.Persistance/MySqlAdapter/appsettings.json" se debe cambiar el string de conexión.

### Hacer Migraciones
```
cd Backend/src/StudentRegistrationApp.Infrastructure/Adapters/Out.Persistance/MySqlAdapter
dotnet ef migrations add InitialCreation
dotnet ef database update
```

## Ejecutar aplicación
```
cd Backend
dotnet run
```

# Frontend
```
cd ../Frontend
npx ng serve
```


# Uso
Una vez que la aplicación esté corriendo, los estudiantes podrán:

 - Registrarse en un máximo de 3 materias.
 - Ver los profesores asignados.
 - Ver la lista de compañeros en cada materia.

# Limitaciones
 - Un estudiante no puede inscribirse en materias dictadas por el mismo profesor más de una vez.
 - Solo se mostrarán los nombres de los compañeros en las clases compartidas con el estudiante.
