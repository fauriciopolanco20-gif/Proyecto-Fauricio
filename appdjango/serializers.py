from rest_framework import serializers
from .models import Clientes, Empleados


class ClienteSerializer(serializers.ModelSerializer):

    nombre_empleado = serializers.CharField(
        source='empleado.nombre',
        read_only=True
    )

    class Meta:
        model = Clientes
        fields = [
            'id',
            'nombre',
            'empleado',
            'nombre_empleado'
        ]


class EmpleadoSerializer(serializers.ModelSerializer):

    class Meta:
        model = Empleados
        fields = '__all__'