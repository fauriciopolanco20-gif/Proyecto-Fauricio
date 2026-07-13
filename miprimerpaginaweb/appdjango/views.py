from django.shortcuts import render, redirect, get_object_or_404
from django.contrib.auth import authenticate, login, logout
from django.contrib import messages

from .models import Clientes, Empleados

from rest_framework import viewsets
from .serializers import ClienteSerializer, EmpleadoSerializer



def login_usuario(request):

    error = False

    if request.method == "POST":

        usuario = request.POST.get('usuario')
        password = request.POST.get('password')

        user = authenticate(
            username=usuario,
            password=password
        )

        if user:
            login(request, user)
            return redirect('/home/')
        else:
            error = True

    return render(request, 'login.html', {
        'error': error
    })



def home(request):

    total_clientes = Clientes.objects.count()
    total_empleados = Empleados.objects.count()

    return render(request, 'home.html', {
        'total_clientes': total_clientes,
        'total_empleados': total_empleados
    })



def cerrar_sesion(request):

    logout(request)
    return redirect('/')



def clientes(request):

    buscar = request.GET.get('buscar')

    if buscar:
        clientes = Clientes.objects.filter(
            nombre__icontains=buscar
        )
    else:
        clientes = Clientes.objects.all()

    return render(request, 'clientes.html', {
        'clientes': clientes,
        'buscar': buscar
    })


def crear_cliente(request):

    empleados = Empleados.objects.all()

    if request.method == "POST":

        nombre = request.POST.get('nombre')
        empleado_id = request.POST.get('empleado')

        print("NOMBRE:", nombre)
        print("EMPLEADO ID:", empleado_id)

        empleado = None

        if empleado_id:
            empleado = get_object_or_404(
                Empleados,
                id=empleado_id
            )

        Clientes.objects.create(
            nombre=nombre,
            empleado=empleado
        )

        messages.success(
            request,
            "Cliente registrado correctamente"
        )

        return redirect('/clientes/')


    return render(
        request,
        'crear_cliente.html',
        {
            'empleados': empleados
        }
    )

def ver_cliente(request, id):

    cliente = get_object_or_404(Clientes, id=id)

    return render(request, 'ver_cliente.html', {
        'cliente': cliente
    })


def editar_cliente(request, id):

    cliente = get_object_or_404(Clientes, id=id)
    empleados = Empleados.objects.all()

    if request.method == "POST":

        cliente.nombre = request.POST.get('nombre')

        empleado_id = request.POST.get('empleado')

        if empleado_id:
            
            cliente.empleado = get_object_or_404(Empleados, id=empleado_id)
        else:
            cliente.empleado = None

        cliente.save()

        messages.success(request, "Cliente actualizado correctamente")
        return redirect('/clientes/')

    return render(request, 'editar_cliente.html', {
        'cliente': cliente,
        'empleados': empleados
    })


def eliminar_cliente(request, id):

    cliente = get_object_or_404(Clientes, id=id)
    cliente.delete()

    messages.success(request, "Cliente eliminado correctamente")

    return redirect('/clientes/')




def empleados(request):

    buscar = request.GET.get('buscar')

    if buscar:
        empleados = Empleados.objects.filter(
            nombre__icontains=buscar
        )
    else:
        empleados = Empleados.objects.all()

    return render(request, 'empleados.html', {
        'empleados': empleados,
        'buscar': buscar
    })


def crear_empleado(request):

    if request.method == "POST":

        nombre = request.POST.get('nombre')

        Empleados.objects.create(
            nombre=nombre
        )

        return redirect('/empleados/')

    return render(request, 'crear_empleado.html')


def editar_empleado(request, id):

    empleado = get_object_or_404(Empleados, id=id)

    if request.method == "POST":

        empleado.nombre = request.POST.get('nombre')
        empleado.save()

        return redirect('/empleados/')

    return render(request, 'editar_empleado.html', {
        'empleado': empleado
    })


def eliminar_empleado(request, id):

    empleado = get_object_or_404(Empleados, id=id)
    empleado.delete()

    return redirect('/empleados/')




class ClienteViewSet(viewsets.ModelViewSet):
    queryset = Clientes.objects.all()
    serializer_class = ClienteSerializer


class EmpleadoViewSet(viewsets.ModelViewSet):
    queryset = Empleados.objects.all()
    serializer_class = EmpleadoSerializer