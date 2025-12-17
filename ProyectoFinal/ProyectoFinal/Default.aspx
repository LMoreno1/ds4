<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" 
    Inherits="ProyectoFinal._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <div class="jumbotron">
            <h1 class="display-4">Sistema de Inscripción de Labor Social</h1>
            <p class="lead">Gestión de proyectos de labor social para estudiantes universitarios</p>
            <hr class="my-4">
            
            <div class="row">
                <div class="col-md-4">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">Estudiantes</h5>
                            <p class="card-text">Registro y gestión de estudiantes</p>
                            <a href="GestionEstudiantes.aspx" class="btn btn-primary">Gestionar</a>
                        </div>
                    </div>
                </div>
                
                <div class="col-md-4">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">Actividades</h5>
                            <p class="card-text">Catálogo de actividades disponibles</p>
                            <a href="GestionActividades.aspx" class="btn btn-primary">Ver Actividades</a>
                        </div>
                    </div>
                </div>
                
                <div class="col-md-4">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">Inscripciones</h5>
                            <p class="card-text">Inscripción a proyectos de labor social</p>
                            <a href="NuevaInscripcion.aspx" class="btn btn-primary">Inscribirse</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        <div class="row mt-4">
            <div class="col-md-6">
                <h4>Proyectos Activos</h4>
                <div id="proyectosActivos">
                </div>
            </div>
            <div class="col-md-6">
                <h4>Estadísticas</h4>
                <div class="list-group">
                    <div class="list-group-item">

                        Estudiantes registrados: <span id="totalEstudiantes" class="badge bg-primary">0</span>
                    </div>
                    <div class="list-group-item">
                        Proyectos disponibles: <span id="totalProyectos" class="badge bg-success">0</span>
                    </div>
                    <div class="list-group-item">
                        Horas cumplidas: <span id="totalHoras" class="badge bg-info">0</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
    <script>
        
        function cargarEstadisticas() {
            $.get('/api/labor-social/estadisticas', function(data) {
                $('#totalEstudiantes').text(data.totalEstudiantes || 0);
                $('#totalProyectos').text(data.totalProyectos || 0);
                $('#totalHoras').text(data.totalHoras || 0);
            });
        }
        
        function cargarProyectosActivos() {
            $.get('/api/labor-social/proyectos-activos', function(data) {
                var html = '';
                data.forEach(function(proyecto) {
                    html += '<div class="card mb-2">';
                    html += '  <div class="card-body">';
                    html += '    <h6>' + proyecto.nombre + '</h6>';
                    html += '    <small>' + proyecto.cupoActual + '/' + proyecto.cupoMaximo + ' cupos</small>';
                    html += '  </div>';
                    html += '</div>';
                });
                $('#proyectosActivos').html(html);
            });
        }
    </script>
</asp:Content>