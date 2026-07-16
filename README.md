# 👥 Sistema de Gestión de Clientes y Empleados (Django)

Este proyecto es una aplicación web desarrollada en **Django** para la gestión y administración de clientes y empleados. Permite registrar, visualizar, editar y eliminar información, almacenada en una base de datos. Además, integra un sistema de autenticación de usuarios y una API RESTful estructurada.

El proyecto está organizado bajo control de versiones con **Git**, estructurado en la rama de desarrollo (`desarrollo`).

---

## 🚀 Características del Proyecto

### 1. CRUD Completo de Clientes y Empleados
* **Clientes:** Registro de nuevos clientes, asociación con un empleado encargado, edición de información y eliminación de registros.
* **Empleados:** Registro de empleados, edición y eliminación de registros, y visualización de la fecha de registro.
* **Buscador:** Filtro de búsqueda en tiempo real por nombre tanto para clientes como para empleados.

### 2. Autenticación y Control de Acceso
* Sistema de inicio de sesión (`login`) y cierre de sesión (`logout`) para proteger el acceso a las funciones del sistema.
* Mensajes interactivos de retroalimentación (`django.contrib.messages`) al realizar operaciones exitosas.

### 3. Interfaz de Usuario Moderna (Bootstrap 5)
* Diseño limpio, responsivo y adaptado para dispositivos móviles.
* Uso de componentes como tarjetas (`cards`), tablas interactivas con efectos de hover, barras de navegación oscuras y botones estilizados.

### 4. API RESTful Integrada
* API estructurada utilizando **Django REST Framework (DRF)**.
* Endpoints disponibles para la integración con otras aplicaciones:
  * `GET /api/clientes/` - Listar clientes.
  * `GET /api/empleados/` - Listar empleados.
  * Acceso completo para crear, actualizar y borrar mediante peticiones HTTP.

---

## 🛠️ Estructura del Código

El proyecto sigue la arquitectura MVT (Modelo-Vista-Template) estándar de Django:

* **[models.py](file:///c:/Users/fauri/OneDrive/Documentos/python/django/miprimerpaginaweb/appdjango/models.py):** Define las tablas `Empleados` y `Clientes` (con relación ForeignKey).
* **[views.py](file:///c:/Users/fauri/OneDrive/Documentos/python/django/miprimerpaginaweb/appdjango/views.py):** Contiene la lógica del negocio para el CRUD, autenticación de usuarios y ViewSets de la API REST.
* **[urls.py](file:///c:/Users/fauri/OneDrive/Documentos/python/django/miprimerpaginaweb/miprimerpaginaweb/urls.py):** Enrutamiento del sistema web y mapeo automático de la API mediante `DefaultRouter`.
* **[templates/](file:///c:/Users/fauri/OneDrive/Documentos/python/django/miprimerpaginaweb/templates/):** Plantillas HTML del sistema:
  * `base.html`: Estructura principal con Bootstrap 5 y navbar.
  * `home.html`: Panel de control principal (dashboard).
  * `clientes.html` y `empleados.html`: Listados con buscadores y opciones CRUD.
  * Formularios de creación y edición.

---

## 🔧 Configuración e Instalación

### Requisitos Previos
* Python 3.10+
* Git
* PostgreSQL (según la configuración actual en `settings.py`) o SQLite (según preferencia).

### Pasos para Ejecutar Localmente

1. **Clonar el repositorio:**
   ```bash
   git clone <url-del-repositorio>
   cd miprimerpaginaweb
   ```

2. **Crear y activar un entorno virtual:**
   ```bash
   python -m venv venv
   # En Windows (PowerShell):
   .\venv\Scripts\Activate.ps1
   # En macOS/Linux:
   source venv/bin/activate
   ```

3. **Instalar las dependencias:**
   ```bash
   pip install django djangorestframework psycopg2
   ```

4. **Realizar las migraciones de la base de datos:**
   ```bash
   python manage.py migrate
   ```

5. **Crear un superusuario para acceder al panel de administración y login:**
   ```bash
   python manage.py createsuperuser
   ```

6. **Iniciar el servidor de desarrollo:**
   ```bash
   python manage.py runserver
   ```
   Accede a la aplicación en `http://127.0.0.1:8000/`.

---

## 📈 Próximas Mejoras (Roadmap de Evolución)
1. **Validaciones robustas mediante Django Forms:** Reemplazar el procesamiento directo de `request.POST` por clases en un archivo `forms.py` para asegurar que los datos ingresados sean limpios y seguros.
2. **Protección de Rutas:** Implementar el decorador `@login_required` en las vistas críticas para evitar accesos no autorizados a través de la URL.
3. **Optimización de la Interfaz Gráfica:** Agregar estilos personalizados (CSS local), transiciones suaves e iconos interactivos para lograr una experiencia de usuario premium.
4. **Token Authentication para la API:** Proteger la API REST para que solo usuarios autorizados puedan consumir los endpoints.
