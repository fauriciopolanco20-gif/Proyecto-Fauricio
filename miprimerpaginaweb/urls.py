"""
URL configuration for miprimerpaginaweb project.

The `urlpatterns` list routes URLs to views. For more information please see:
    https://docs.djangoproject.com/en/6.0/topics/http/urls/
Examples:
Function views
    1. Add an import:  from my_app import views
    2. Add a URL to urlpatterns:  path('', views.home, name='home')
Class-based views
    1. Add an import:  from other_app.views import Home
    2. Add a URL to urlpatterns:  path('', Home.as_view(), name='home')
Including another URLconf
    1. Import the include() function: from django.urls import include, path
    2. Add a URL to urlpatterns:  path('blog/', include('blog.urls'))
"""
from django.contrib import admin
from django.urls import path, include
from appdjango import views
from rest_framework import routers
from appdjango.views import ClienteViewSet, EmpleadoViewSet

router = routers.DefaultRouter()

router.register(r'clientes', ClienteViewSet)

router.register(r'empleados', EmpleadoViewSet)

urlpatterns = [

    path('admin/', admin.site.urls),

    path('', views.login_usuario),
    path('logout/', views.cerrar_sesion),

   
    path('home/', views.home),

    
    path('clientes/', views.clientes),
    path('cliente/crear/', views.crear_cliente),
    path('cliente/<int:id>/', views.ver_cliente),
    path('cliente/editar/<int:id>/', views.editar_cliente),
    path('cliente/eliminar/<int:id>/', views.eliminar_cliente),

    path('empleados/', views.empleados),
    path('empleado/crear/', views.crear_empleado),
    path('empleado/editar/<int:id>/', views.editar_empleado),
    path('empleado/eliminar/<int:id>/', views.eliminar_empleado),

    
    path('api/', include(router.urls)),
]