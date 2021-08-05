Public Interface InterfaceTablas

    Function guardar() As Boolean 'Este metodo se ocupara para guardarLaInformacionDlaClase 'INSERT
    Function actualizar() As Boolean 'Actualizara los datos la CLASE 'UPDATE
    Function eliminar() As Boolean 'Eliminara la informacion de la CLASE o cambiara el esActivo a False en caso de que no se permite eliminar
    Function buscarPID() As Boolean 'Buscar por medio del ID de la CLASE
    Function getDetalleMod() As String 'Obtiene usuario que modifico y actualizo por ultima vez el registro...

    Function validaDatos(nuevo As Boolean) As Boolean 'Validara si todos los campos estan llenos para evitar que falte alguno necesario antes de guardar

    Function getCreadoPor() As Empleado 'Obtiene los datosDesdelaClaseEmpleado
    Function getActualizadoPor() As Empleado 'Obtiene los datosDesdelaClaseEmpleado
    Function getEmpresa() As Empresa 'Obtiene los datosDesdelaClase Empresa
    Function getSucursal() As Sucursal 'Obtiene los datosDesdelaClase Sucursal

    Sub seteaDatos(rdr As SqlClient.SqlDataReader) 'Setea todos los datos desde el READER.
    Function armaQry(accion As String, esInsert As Boolean) As Boolean 'ArmaQry a Ejecutar!!

End Interface
