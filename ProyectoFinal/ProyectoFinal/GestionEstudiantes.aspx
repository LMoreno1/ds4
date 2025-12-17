<%@ Page Title="Gestión de Estudiantes" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="GestionEstudiantes.aspx.cs" 
    Inherits="ProyectoFinal.GestionEstudiantes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <div class="d-flex justify-content-between align-items-center mb-4">
            <h2><i class="fas fa-users me-2"></i>Gestión de Estudiantes</h2>
            <button class="btn btn-success" data-bs-toggle="modal" data-bs-target="#modalEstudiante">
                <i class="fas fa-plus me-1"></i> Nuevo Estudiante
            </button>
        </div>
        
        <div class="row mb-4">
            <div class="col-md-3">
                <div class="card text-white bg-primary">
                    <div class="card-body">
                        <h5 class="card-title">Total Estudiantes</h5>
                        <h2 id="totalEstudiantes">0</h2>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card text-white bg-success">
                    <div class="card-body">
                        <h5 class="card-title">Activos</h5>
                        <h2 id="estudiantesActivos">0</h2>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card text-white bg-warning">
                    <div class="card-body">
                        <h5 class="card-title">Con Inscripción</h5>
                        <h2 id="estudiantesInscritos">0</h2>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card text-white bg-info">
                    <div class="card-body">
                        <h5 class="card-title">Horas Cumplidas</h5>
                        <h2 id="totalHoras">0</h2>
                    </div>
                </div>
            </div>
        </div>
        
        <div class="card">
            <div class="card-header">
                <h5 class="mb-0">Lista de Estudiantes</h5>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <table class="table table-striped table-hover" id="tablaEstudiantes">
                        <thead>
                            <tr>
                                <th>Codigo</th>
                                <th>Nombre</th>
                                <th>Email</th>
                                <th>Carrera</th>
                                <th>Semestre</th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    
    <div class="modal fade" id="modalEstudiante" tabindex="-1">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Registrar Nuevo Estudiante</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                </div>
                <div class="modal-body">
                    <form id="formEstudiante">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="mb-3">
                                    <label class="form-label">Codigo *</label>
                                    <input type="text" class="form-control" id="txtCodigo" required>
                                </div>
                                <div class="mb-3">
                                    <label class="form-label">Nombre *</label>
                                    <input type="text" class="form-control" id="txtNombres" required>
                                </div>
                                <div class="mb-3">
                                    <label class="form-label">Email *</label>
                                    <input type="text" class="form-control" id="txtEmail" required>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="mb-3">
                                    <label class="form-label">Carrera *</label>
                                    <select class="form-select" id="ddlCarrera" required>
                                        <option value="">Seleccionar</option>
                                        <option>Ingeniería de Sistemas de Información Gerencial</option>
                                        <option>Ingeniería de Sistemas de Información</option>
                                        <option>Ingeniería de Sistemas y Computación</option>
                                        <option>Ingeniería de Software</option>
                                        <option>Licenciatura en Desarrollo y Gestión de Software</option>
                                        <option>Licenciatura en Ciberseguridad</option>
                                        <option>Licenciatura en Informática Aplicada a la Educación</option>
                                        <option>Licenciatura en Redes Informáticas</option>
                                    </select>
                                </div>
                                <div class="mb-3">
                                    <label class="form-label">Semestre *</label>
                                    <input type="text" class="form-control" id="txtSemestre" required>
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-primary" onclick="guardarEstudiante()">
                        <i class="fas fa-save me-1"></i> Guardar
                    </button>

                </div>
            </div>
        </div>
    </div>
    

</asp:Content>