<%@ Page Title="Nueva Inscripción" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="NuevaInscripcion.aspx.cs" 
    Inherits="ProyectoFinal.NuevaInscripcion" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2><i class="fas fa-file-signature me-2"></i>Nueva Inscripción</h2>
        <p class="text-muted">Registra una nueva inscripción a labor social</p>
        
        <div class="card">
            <div class="card-body">
                <form>
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label class="form-label">Estudiante *</label>
                            <select class="form-select" required>
                                <option value="">Seleccionar estudiante</option>
                                <option>Juan Pérez López (A20251)</option>
                                <option>María García Martínez (B20251)</option>
                            </select>
                        </div>
                        <div class="col-md-6">
                            <label class="form-label">Actividad *</label>
                            <select class="form-select" required>
                                <option value="">Seleccionar actividad</option>
                                <option>Reciclaje en campus</option>
                                <option>Tutorías a estudiantes</option>
                                <option>Limpieza de áreas verdes</option>
                                <option>Digitalización de planos</option>
                                <option>Clasificar togas de graduación</option>
                                <option>Actualización de inventario</option>
                            </select>
                        </div>
                    </div>
                    
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label class="form-label">Fecha de inicio *</label>
                            <input type="date" class="form-control" required>
                        </div>
                        <div class="col-md-6">
                            <label class="form-label">Horas requeridas *</label>
                            <input type="number" class="form-control" min="1" max="100" value="20" required>
                        </div>
                    </div>
                    
                    <div class="mb-3">
                        <label class="form-label">Observaciones</label>
                        <textarea class="form-control" rows="3"></textarea>
                    </div>
                    
                    <div class="d-flex justify-content-between">
                        <a href="Default.aspx" class="btn btn-secondary">Cancelar</a>
                        <button type="submit" class="btn btn-success">
                            <i class="fas fa-check me-1"></i> Registrar Inscripción
                        </button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>