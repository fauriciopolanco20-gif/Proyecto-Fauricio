from django.db import models

class Empleados(models.Model):
    nombre = models.CharField(max_length=100)
    fecha = models.DateTimeField(auto_now_add=True)

    def __str__(self):
        return self.nombre



class Clientes(models.Model):
    nombre = models.CharField(max_length=100)
    empleado = models.ForeignKey(Empleados, on_delete=models.CASCADE)

    def __str__(self):
        return self.nombre