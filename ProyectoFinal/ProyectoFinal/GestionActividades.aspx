<%@ Page Title="Gestión de Actividades" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="GestionActividades.aspx.cs" 
    Inherits="ProyectoFinal.GestionActividades" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">

        <div id="alertContainer"></div>
        
 
        <div class="d-flex justify-content-between align-items-center mb-4">
            <div>
                <h2 class="mb-1"><i class="fas fa-tasks text-primary me-2"></i>Gestión de Actividades</h2>
                <p class="text-muted mb-0">Administra el catálogo de actividades de labor social</p>
            </div>
            <button class="btn btn-success" data-bs-toggle="modal" data-bs-target="#modalActividad">
                <i class="fas fa-plus me-1"></i> Nueva Actividad
            </button>
        </div>
        

        <div class="row g-3 mb-4">
            <div class="col-md-3">
                <div class="card border-start border-primary border-4 shadow-sm">
                    <div class="card-body">
                        <div class="d-flex justify-content-between align-items-center">
                            <div>
                                <h6 class="text-muted mb-1">Total Actividades</h6>
                                <h3 class="mb-0 text-primary" id="totalActividades">0</h3>
                            </div>
                            <div class="bg-primary bg-opacity-10 p-3 rounded">
                                <i class="fas fa-tasks text-primary fs-4"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
            <div class="col-md-3">
                <div class="card border-start border-success border-4 shadow-sm">
                    <div class="card-body">
                        <div class="d-flex justify-content-between align-items-center">
                            <div>
                                <h6 class="text-muted mb-1">Disponibles</h6>
                                <h3 class="mb-0 text-success" id="actividadesDisponibles">0</h3>
                            </div>
                            <div class="bg-success bg-opacity-10 p-3 rounded">
                                <i class="fas fa-check-circle text-success fs-4"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
            <div class="col-md-3">
                <div class="card border-start border-warning border-4 shadow-sm">
                    <div class="card-body">
                        <div class="d-flex justify-content-between align-items-center">
                            <div>
                                <h6 class="text-muted mb-1">Con Cupo</h6>
                                <h3 class="mb-0 text-warning" id="actividadesConCupo">0</h3>
                            </div>
                            <div class="bg-warning bg-opacity-10 p-3 rounded">
                                <i class="fas fa-user-friends text-warning fs-4"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
            <div class="col-md-3">
                <div class="card border-start border-info border-4 shadow-sm">
                    <div class="card-body">
                        <div class="d-flex justify-content-between align-items-center">
                            <div>
                                <h6 class="text-muted mb-1">Horas Totales</h6>
                                <h3 class="mb-0 text-info" id="totalHoras">0</h3>
                            </div>
                            <div class="bg-info bg-opacity-10 p-3 rounded">
                                <i class="fas fa-clock text-info fs-4"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
  
        <div class="card shadow-sm">
            <div class="card-header bg-light">
                <h5 class="mb-0"><i class="fas fa-list me-2"></i>Catálogo de Actividades</h5>
            </div>
            <div class="card-body p-0">
                <div class="table-responsive">
                    <table class="table table-hover mb-0" id="tablaActividades">
                        <thead class="table-light">
                            <tr>
                                <th>Código</th>
                                <th>Nombre</th>
                                <th>Descripción</th>
                                <th>Fecha</th>
                                <th>Cupo</th>
                                <th>Estado</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tbody id="tbodyActividades">
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    
 
    <div class="modal fade" id="modalActividad" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalTitulo">Nueva Actividad</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                </div>
                <div class="modal-body">
                    <form id="formActividad">
                        <input type="hidden" id="hdnActividadId" value="0">
                        
                        <div class="mb-3">
                            <label class="form-label">Nombre *</label>
                            <input type="text" class="form-control" id="txtNombre" required 
                                   placeholder="Ej: Reciclaje en campus">
                        </div>
                        
                        <div class="mb-3">
                            <label class="form-label">Descripción</label>
                            <textarea class="form-control" id="txtDescripcion" rows="2" 
                                      placeholder="Describe brevemente la actividad..."></textarea>
                        </div>
                        
                        <div class="row g-3">
                            <div class="col-md-6">
                                <div class="mb-3">
                                    <label class="form-label">Fecha *</label>
                                    <input type="date" class="form-control" id="txtFecha" required>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="mb-3">
                                    <label class="form-label">Cupo Máximo *</label>
                                    <input type="number" class="form-control" id="txtCupoMaximo" 
                                           min="1" max="100" required value="20">
                                </div>
                            </div>
                        </div>
                        
                        <div class="mb-3">
                            <label class="form-label">Lugar *</label>
                            <input type="text" class="form-control" id="txtLugar" required 
                                   placeholder="Ej: Campus Central, Biblioteca">
                        </div>
                        
                        <div class="mb-3">
                            <label class="form-label">Estado</label>
                            <select class="form-select" id="ddlEstado">
                                <option value="Disponible" selected>Disponible</option>
                                <option value="En proceso">En proceso</option>
                                <option value="Completada">Completada</option>
                                <option value="Cancelada">Cancelada</option>
                            </select>
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-primary" id="btnGuardarActividad">
                        <i class="fas fa-save me-1"></i> Guardar
                    </button>
                </div>
            </div>
        </div>
    </div>
   
    <div class="modal fade" id="modalDetalles" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title"><i class="fas fa-info-circle me-2"></i>Detalles de Actividad</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                </div>
                <div class="modal-body" id="detallesContenido">
      
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    
    <script>

        var todasActividades = [];
        var modoEdicion = false;


        function configurarFecha() {
     
            var hoy = new Date().toISOString().split('T')[0];
            $('#txtFecha').attr('min', hoy);
            $('#txtFecha').val(hoy);
        }

        function configurarEventos() {
 
            $('#btnGuardarActividad').on('click', guardarActividad);

    
            $('#modalActividad').on('hidden.bs.modal', function () {
                resetModal();
            });
        }

        function resetModal() {
            $('#hdnActividadId').val('0');
            $('#txtNombre').val('');
            $('#txtDescripcion').val('');
            $('#txtCupoMaximo').val('20');
            $('#txtLugar').val('');
            $('#ddlEstado').val('Disponible');
            configurarFecha();
            $('#modalTitulo').text('Nueva Actividad');
            $('#btnGuardarActividad').html('<i class="fas fa-save me-1"></i> Guardar');
            modoEdicion = false;
        }

        function cargarActividades() {
            $.ajax({
                url: '<%= ResolveUrl("~/api/actividad/disponibles") %>',
                type: 'GET',
                success: function (data) {

                todasActividades = Array.isArray(data) ? data : [];

                mostrarActividades(todasActividades);
                actualizarEstadisticas(todasActividades);
            },
            error: function (xhr) {
                console.error(xhr);
                mostrarAlerta('No se pudieron cargar las actividades desde la base de datos', 'danger');
                mostrarActividades([]);
            }
            });
        }


        function mostrarActividades(actividades) {
            var tbody = $('#tbodyActividades');
            tbody.empty();

            if (actividades.length === 0) {
                tbody.append(`
                    <tr>
                        <td colspan="7" class="text-center py-5">
                            <div class="text-muted">
                                <i class="fas fa-inbox fa-3x mb-3"></i>
                                <h5>No hay actividades registradas</h5>
                                <p>Crea tu primera actividad para comenzar</p>
                            </div>
                        </td>
                    </tr>
                `);
                return;
            }

            actividades.forEach(function (act) {
           
                var cuposInfo = '';
                if (act.Estado === 'Disponible' && act.CuposDisponibles !== undefined) {
                    cuposInfo = `
                        <div class="small">
                            <span class="badge ${act.CuposDisponibles > 0 ? 'bg-success' : 'bg-secondary'}">
                                ${act.CuposDisponibles} disponible${act.CuposDisponibles !== 1 ? 's' : ''}
                            </span>
                        </div>
                    `;
                }


                var estadoColor = 'bg-secondary';
                switch (act.Estado) {
                    case 'Disponible': estadoColor = 'bg-success'; break;
                    case 'En proceso': estadoColor = 'bg-primary'; break;
                    case 'Completada': estadoColor = 'bg-info'; break;
                    case 'Cancelada': estadoColor = 'bg-danger'; break;
                }

                var row = `
                    <tr>
                        <td>
                            <strong class="text-primary">ACT-${act.Id.toString().padStart(3, '0')}</strong>
                        </td>
                        <td>
                            <strong>${act.Nombre || 'Sin nombre'}</strong><br>
                            <small class="text-muted">${act.Lugar || 'No especificado'}</small>
                        </td>
                        <td>
                            <small class="text-truncate d-inline-block" style="max-width: 200px;" 
                                   title="${act.Descripcion || ''}">
                                ${act.Descripcion || 'Sin descripción'}
                            </small>
                        </td>
                        <td>
                            <small>${formatFecha(act.Fecha)}</small>
                        </td>
                        <td>
                            <div>${act.CupoMaximo || 0} cupos</div>
                            ${cuposInfo}
                        </td>
                        <td>
                            <span class="badge ${estadoColor}">${act.Estado || 'Desconocido'}</span>
                        </td>
                        <td>
                            <div class="btn-group btn-group-sm">
                                <button class="btn btn-outline-info" onclick="verActividad(${act.Id})" 
                                        title="Ver detalles" data-bs-toggle="tooltip">
                                    <i class="fas fa-eye"></i>
                                </button>
                                <button class="btn btn-outline-warning" onclick="editarActividad(${act.Id})" 
                                        title="Editar" data-bs-toggle="tooltip">
                                    <i class="fas fa-edit"></i>
                                </button>
                                <button class="btn btn-outline-danger" onclick="eliminarActividad(${act.Id})" 
                                        title="Eliminar" data-bs-toggle="tooltip">
                                    <i class="fas fa-trash"></i>
                                </button>
                            </div>
                        </td>
                    </tr>
                `;
                tbody.append(row);
            });

            $('[data-bs-toggle="tooltip"]').tooltip();
        }

        function actualizarEstadisticas(actividades) {
            var total = actividades.length;
            var disponibles = actividades.filter(a => a.Estado === 'Disponible').length;
            var conCupo = actividades.filter(a => {
                if (a.Estado !== 'Disponible') return false;
                return (a.CuposDisponibles || 0) > 0;
            }).length;
            var totalHoras = total * 40;

            $('#totalActividades').text(total);
            $('#actividadesDisponibles').text(disponibles);
            $('#actividadesConCupo').text(conCupo);
            $('#totalHoras').text(totalHoras);
        }

        function formatFecha(fechaString) {
            if (!fechaString) return 'No especificada';
            try {
                var fecha = new Date(fechaString);
                return fecha.toLocaleDateString('es-ES', {
                    day: '2-digit',
                    month: 'short',
                    year: 'numeric'
                });
            } catch (e) {
                return fechaString;
            }
        }

        function guardarActividad() {
            if (!$('#txtNombre').val() || !$('#txtFecha').val() ||
                !$('#txtCupoMaximo').val() || !$('#txtLugar').val()) {
                mostrarAlerta('Por favor complete todos los campos requeridos (*)', 'warning');
                return;
            }

            var actividad = {
                Nombre: $('#txtNombre').val(),
                Descripcion: $('#txtDescripcion').val(),
                Fecha: $('#txtFecha').val(),
                CupoMaximo: parseInt($('#txtCupoMaximo').val()),
                Lugar: $('#txtLugar').val(),
                Estado: $('#ddlEstado').val()
            };

            var metodo = 'POST';
            var url = '/api/actividad';
            var mensajeExito = 'Actividad creada exitosamente';

    
            if (modoEdicion) {
                var id = $('#hdnActividadId').val();
                metodo = 'PUT';
                url = '/api/actividad/' + id;
                mensajeExito = 'Actividad actualizada exitosamente';
            }

    
            $('#btnGuardarActividad').prop('disabled', true).html('<i class="fas fa-spinner fa-spin me-1"></i> Guardando...');

            $.ajax({
                url: url,
                type: metodo,
                contentType: 'application/json',
                data: JSON.stringify(actividad),
                success: function (response) {
                    mostrarAlerta(mensajeExito, 'success');
                    $('#modalActividad').modal('hide');
                    cargarActividades();
                },
                error: function (xhr, status, error) {
                    var errorMsg = 'Error al guardar actividad';
                    if (xhr.responseJSON && xhr.responseJSON.Message) {
                        errorMsg += ': ' + xhr.responseJSON.Message;
                    } else if (xhr.statusText) {
                        errorMsg += ': ' + xhr.statusText;
                    }
                    mostrarAlerta(errorMsg, 'danger');
                },
                complete: function () {
                    $('#btnGuardarActividad').prop('disabled', false).html('<i class="fas fa-save me-1"></i> Guardar');
                }
            });
        }

        function verActividad(id) {
            $.ajax({
                url: '/api/actividad/' + id,
                type: 'GET',
                success: function (actividad) {
                    var detalles = `
                        <div class="mb-3">
                            <h6 class="text-primary">ACT-${actividad.Id.toString().padStart(3, '0')}</h6>
                            <h5>${actividad.Nombre || 'Sin nombre'}</h5>
                        </div>
                        
                        <div class="mb-3">
                            <strong><i class="fas fa-align-left me-2"></i>Descripción:</strong>
                            <p class="mb-0">${actividad.Descripcion || 'Sin descripción'}</p>
                        </div>
                        
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <strong><i class="fas fa-calendar me-2"></i>Fecha:</strong>
                                <p class="mb-0">${formatFecha(actividad.Fecha)}</p>
                            </div>
                            <div class="col-md-6">
                                <strong><i class="fas fa-users me-2"></i>Cupo Máximo:</strong>
                                <p class="mb-0">${actividad.CupoMaximo || 0}</p>
                            </div>
                        </div>
                        
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <strong><i class="fas fa-map-marker-alt me-2"></i>Lugar:</strong>
                                <p class="mb-0">${actividad.Lugar || 'No especificado'}</p>
                            </div>
                            <div class="col-md-6">
                                <strong><i class="fas fa-info-circle me-2"></i>Estado:</strong>
                                <p class="mb-0">
                                    <span class="badge ${actividad.Estado === 'Disponible' ? 'bg-success' :
                            actividad.Estado === 'En proceso' ? 'bg-primary' :
                                actividad.Estado === 'Completada' ? 'bg-info' :
                                    actividad.Estado === 'Cancelada' ? 'bg-danger' : 'bg-secondary'}">
                                        ${actividad.Estado || 'Desconocido'}
                                    </span>
                                </p>
                            </div>
                        </div>
                        
                        ${actividad.Estado === 'Disponible' ? `
                            <div class="alert alert-info">
                                <i class="fas fa-info-circle me-2"></i>
                                Para ver cupos disponibles, consulta la lista de actividades disponibles.
                            </div>
                        ` : ''}
                    `;

                    $('#detallesContenido').html(detalles);
                    $('#modalDetalles').modal('show');
                },
                error: function () {
                    mostrarAlerta('Error al cargar los detalles de la actividad', 'danger');
                }
            });
        }

        function editarActividad(id) {
            $.ajax({
                url: '/api/actividad/' + id,
                type: 'GET',
                success: function (actividad) {
  
                    $('#hdnActividadId').val(actividad.Id);
                    $('#txtNombre').val(actividad.Nombre || '');
                    $('#txtDescripcion').val(actividad.Descripcion || '');
                    $('#txtFecha').val(actividad.Fecha ? actividad.Fecha.split('T')[0] : '');
                    $('#txtCupoMaximo').val(actividad.CupoMaximo || 20);
                    $('#txtLugar').val(actividad.Lugar || '');
                    $('#ddlEstado').val(actividad.Estado || 'Disponible');

 
                    $('#modalTitulo').text('Editar Actividad');
                    $('#btnGuardarActividad').html('<i class="fas fa-save me-1"></i> Actualizar');
                    modoEdicion = true;

      
                    $('#modalActividad').modal('show');
                },
                error: function () {
                    mostrarAlerta('Error al cargar la actividad para editar', 'danger');
                }
            });
        }

        function eliminarActividad(id) {
            if (!confirm('¿Está seguro de eliminar esta actividad? Esta acción no se puede deshacer.')) {
                return;
            }

            $.ajax({
                url: '/api/actividad/' + id,
                type: 'DELETE',
                success: function (response) {
                    if (response && response.success) {
                        mostrarAlerta('Actividad eliminada exitosamente', 'success');
                        cargarActividades();
                    } else {
                        mostrarAlerta('Error: ' + (response.message || 'No se pudo eliminar'), 'danger');
                    }
                },
                error: function (xhr) {
                    var errorMsg = 'Error al eliminar actividad';
                    if (xhr.responseJSON && xhr.responseJSON.Message) {
                        errorMsg += ': ' + xhr.responseJSON.Message;
                    }
                    mostrarAlerta(errorMsg, 'danger');
                }
            });
        }

        function mostrarAlerta(mensaje, tipo) {
            var icono = '';
            switch (tipo) {
                case 'success': icono = 'fa-check-circle'; break;
                case 'danger': icono = 'fa-exclamation-triangle'; break;
                case 'warning': icono = 'fa-exclamation-circle'; break;
                default: icono = 'fa-info-circle';
            }

            var alerta = `
                <div class="alert alert-${tipo} alert-dismissible fade show" role="alert">
                    <i class="fas ${icono} me-2"></i>
                    ${mensaje}
                    <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
                </div>
            `;

            $('#alertContainer').html(alerta);


            setTimeout(function () {
                $('.alert').alert('close');
            }, 5000);
        }
    </script>
</asp:Content>