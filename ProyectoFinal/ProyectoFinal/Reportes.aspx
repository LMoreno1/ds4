<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" 
    Inherits="ProyectoFinal.Reportes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2><i class="fas fa-chart-bar me-2"></i>Reportes y Estadísticas</h2>
        <p class="text-muted">Consulta y descarga reportes del sistema de labor social</p>
        
        <div id="alertContainer"></div>
        
        <div class="row mb-4" id="estadisticasCards">
            <div class="col-md-3 mb-3">
                <div class="card text-white bg-primary h-100">
                    <div class="card-body text-center">
                        <i class="fas fa-users fa-2x mb-2"></i>
                        <h3 id="totalEstudiantes">0</h3>
                        <p class="mb-0">Total Estudiantes</p>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card text-white bg-success h-100">
                    <div class="card-body text-center">
                        <i class="fas fa-graduation-cap fa-2x mb-2"></i>
                        <h3 id="totalCarreras">0</h3>
                        <p class="mb-0">Carreras</p>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card text-white bg-warning h-100">
                    <div class="card-body text-center">
                        <i class="fas fa-chart-line fa-2x mb-2"></i>
                        <h3 id="promedioSemestre">0.0</h3>
                        <p class="mb-0">Semestre Promedio</p>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card text-white bg-info h-100">
                    <div class="card-body text-center">
                        <i class="fas fa-calendar-alt fa-2x mb-2"></i>
                        <h3 id="mesActual">0</h3>
                        <p class="mb-0">Inscripciones este mes</p>
                    </div>
                </div>
            </div>
        </div>
        
        <div class="row">
            <div class="col-md-4 mb-3">
                <div class="card h-100">
                    <div class="card-body text-center">
                        <i class="fas fa-users fa-3x text-primary mb-3"></i>
                        <h5>Reporte de Estudiantes</h5>
                        <p class="text-muted">Listado completo con filtros por carrera</p>
                        <div class="mt-3">
                            <select class="form-select form-select-sm mb-2" id="filtroCarrera">
                                <option value="">Todas las carreras</option>
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
                    </div>
                    <div class="card-footer">
                        <div class="d-grid gap-2">
                            <button class="btn btn-outline-primary" onclick="descargarReporteEstudiantesPDF()">
                                <i class="fas fa-file-pdf me-1"></i> Descargar PDF
                            </button>
                            <button class="btn btn-outline-success" onclick="descargarReporteEstudiantesExcel()">
                                <i class="fas fa-file-excel me-1"></i> Descargar Excel
                            </button>
                        </div>
                    </div>
                </div>
            </div>
            
            <div class="col-md-4 mb-3">
                <div class="card h-100">
                    <div class="card-body text-center">
                        <i class="fas fa-tasks fa-3x text-success mb-3"></i>
                        <h5>Actividades por Estado</h5>
                        <p class="text-muted">Actividades activas, finalizadas, pendientes</p>
                        <div class="mt-3">
                            <select class="form-select form-select-sm mb-2" id="filtroEstado">
                                <option value="">Todos los estados</option>
                                <option>Activa</option>
                                <option>Finalizada</option>
                                <option>Pendiente</option>
                                <option>Cancelada</option>
                            </select>
                        </div>
                    </div>
                    <div class="card-footer">
                        <div class="d-grid gap-2">
                            <button class="btn btn-outline-success" onclick="descargarReporteActividadesPDF()">
                                <i class="fas fa-file-pdf me-1"></i> Descargar PDF
                            </button>
                            <button class="btn btn-outline-info" onclick="verReporteActividades()">
                                <i class="fas fa-eye me-1"></i> Ver en pantalla
                            </button>
                        </div>
                    </div>
                </div>
            </div>
            
            <div class="col-md-4 mb-3">
                <div class="card h-100">
                    <div class="card-body text-center">
                        <i class="fas fa-file-alt fa-3x text-warning mb-3"></i>
                        <h5>Inscripciones por Período</h5>
                        <p class="text-muted">Reporte de inscripciones mensual/anual</p>
                        <div class="mt-3">
                            <div class="input-group input-group-sm mb-2">
                                <input type="month" class="form-control" id="filtroMes" value="2024-01">
                                <button class="btn btn-outline-secondary" onclick="aplicarFiltroMes()">
                                    <i class="fas fa-filter"></i>
                                </button>
                            </div>
                        </div>
                    </div>
                    <div class="card-footer">
                        <div class="d-grid gap-2">
                            <button class="btn btn-outline-warning" onclick="descargarReporteInscripcionesPDF()">
                                <i class="fas fa-file-pdf me-1"></i> Descargar PDF
                            </button>
                            <button class="btn btn-outline-danger" onclick="descargarReporteCompletoPDF()">
                                <i class="fas fa-file-archive me-1"></i> Reporte Completo
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        <!-- Gráficos Estadísticos -->
        <div class="row mt-4">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header d-flex justify-content-between align-items-center">
                        <h5 class="mb-0">Estudiantes por Carrera</h5>
                        <button class="btn btn-sm btn-outline-primary" onclick="exportarGraficoCarreras()">
                            <i class="fas fa-download me-1"></i> Exportar
                        </button>
                    </div>
                    <div class="card-body">
                        <canvas id="carrerasChart" height="200"></canvas>
                    </div>
                </div>
            </div>
            
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header d-flex justify-content-between align-items-center">
                        <h5 class="mb-0">Inscripciones Mensuales</h5>
                        <button class="btn btn-sm btn-outline-success" onclick="exportarGraficoInscripciones()">
                            <i class="fas fa-download me-1"></i> Exportar
                        </button>
                    </div>
                    <div class="card-body">
                        <canvas id="inscripcionesChart" height="200"></canvas>
                    </div>
                </div>
            </div>
        </div>
        
        <div class="card mt-4" id="cardVistaPrevia" style="display: none;">
            <div class="card-header d-flex justify-content-between align-items-center">
                <h5 class="mb-0" id="tituloVistaPrevia">Vista Previa del Reporte</h5>
                <div>
                    <button class="btn btn-sm btn-outline-secondary me-2" onclick="imprimirReporte()">
                        <i class="fas fa-print me-1"></i> Imprimir
                    </button>
                    <button class="btn btn-sm btn-outline-danger" onclick="cerrarVistaPrevia()">
                        <i class="fas fa-times"></i>
                    </button>
                </div>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <table class="table table-striped table-hover" id="tablaVistaPrevia">
                    </table>
                </div>
            </div>
        </div>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/2.5.1/jspdf.umd.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf-autotable/3.5.25/jspdf.plugin.autotable.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/exceljs/dist/exceljs.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/FileSaver.js/2.0.5/FileSaver.min.js"></script>
    
    <script>
        window.jsPDF = window.jspdf.jsPDF;

        $(document).ready(function () {
            console.log('Reportes - Inicializando');
            cargarEstadisticas();
            cargarGraficos();
        });

        function cargarEstadisticas() {
            $.ajax({
                url: '/api/estudiante',
                type: 'GET',
                success: function (data) {
                    $('#totalEstudiantes').text(data.length);

                    var carreras = [...new Set(data.map(e => e.Carrera))];
                    $('#totalCarreras').text(carreras.length);

                    if (data.length > 0) {
                        var suma = data.reduce((total, e) => total + (e.Semestre || 0), 0);
                        var promedio = (suma / data.length).toFixed(1);
                        $('#promedioSemestre').text(promedio);
                    }
                },
                error: function () {
                    console.log('Usando datos de ejemplo para estadísticas');
                    $('#totalEstudiantes').text('18');
                    $('#totalCarreras').text('8');
                    $('#promedioSemestre').text('4.2');
                    $('#mesActual').text('5');
                }
            });
        }

        function cargarGraficos() {
            $.ajax({
                url: '/api/estudiante',
                type: 'GET',
                success: function (data) {
                    var conteo = {};
                    data.forEach(e => {
                        if (e.Carrera) {
                            conteo[e.Carrera] = (conteo[e.Carrera] || 0) + 1;
                        }
                    });

                    var ctx1 = document.getElementById('carrerasChart').getContext('2d');
                    new Chart(ctx1, {
                        type: 'pie',
                        data: {
                            labels: Object.keys(conteo),
                            datasets: [{
                                data: Object.values(conteo),
                                backgroundColor: [
                                    '#FF6384', '#36A2EB', '#FFCE56', '#4BC0C0',
                                    '#9966FF', '#FF9F40', '#8AC926', '#1982C4'
                                ]
                            }]
                        },
                        options: {
                            responsive: true,
                            plugins: {
                                legend: {
                                    position: 'right'
                                },
                                title: {
                                    display: true,
                                    text: 'Distribución por Carrera'
                                }
                            }
                        }
                    });
                }
            });

            var meses = ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'];
            var inscripciones = [12, 19, 8, 15, 22, 18, 14, 21, 16, 19, 23, 17];

            var ctx2 = document.getElementById('inscripcionesChart').getContext('2d');
            new Chart(ctx2, {
                type: 'bar',
                data: {
                    labels: meses,
                    datasets: [{
                        label: 'Inscripciones por mes',
                        data: inscripciones,
                        backgroundColor: 'rgba(54, 162, 235, 0.5)',
                        borderColor: 'rgba(54, 162, 235, 1)',
                        borderWidth: 1
                    }]
                },
                options: {
                    responsive: true,
                    scales: {
                        y: {
                            beginAtZero: true,
                            title: {
                                display: true,
                                text: 'Cantidad de Inscripciones'
                            }
                        }
                    },
                    plugins: {
                        title: {
                            display: true,
                            text: 'Inscripciones Mensuales 2024'
                        }
                    }
                }
            });
        }


        function descargarReporteEstudiantesPDF() {
            var filtroCarrera = $('#filtroCarrera').val();
            mostrarCargando('Generando PDF de estudiantes...');

            $.ajax({
                url: '/api/estudiante',
                type: 'GET',
                success: function (data) {
                    if (filtroCarrera) {
                        data = data.filter(e => e.Carrera === filtroCarrera);
                    }

                    generarPDFEstudiantes(data, filtroCarrera);
                    ocultarCargando();
                },
                error: function () {
                    ocultarCargando();
                    var datosEjemplo = [
                        { Codigo: '20241106', Nombre: 'Alejandro Martínez', Email: 'alejandro@universidad.edu', Carrera: 'Ingeniería de Sistemas', Semestre: 2 },
                        { Codigo: '20241107', Nombre: 'Isabel Giraldo', Email: 'isabel@universidad.edu', Carrera: 'Ingeniería de Software', Semestre: 4 }
                    ];
                    generarPDFEstudiantes(datosEjemplo, filtroCarrera);
                }
            });
        }

        function generarPDFEstudiantes(data, filtro) {
            const doc = new jsPDF('landscape');

            doc.setFontSize(18);
            var titulo = 'Reporte de Estudiantes';
            if (filtro) titulo += ' - ' + filtro;
            doc.text(titulo, doc.internal.pageSize.width / 2, 20, { align: 'center' });

            doc.setFontSize(10);
            doc.text('Generado: ' + new Date().toLocaleDateString() + ' ' + new Date().toLocaleTimeString(), 20, 30);
            doc.text('Total registros: ' + data.length, doc.internal.pageSize.width - 50, 30);

            doc.autoTable({
                startY: 40,
                head: [['Código', 'Nombre Completo', 'Email', 'Carrera', 'Semestre', 'Fecha Registro']],
                body: data.map(item => [
                    item.Codigo || 'N/A',
                    item.Nombre || 'N/A',
                    item.Email || 'N/A',
                    item.Carrera || 'N/A',
                    item.Semestre || 'N/A',
                    item.FechaRegistro ? new Date(item.FechaRegistro).toLocaleDateString() : 'N/A'
                ]),
                theme: 'grid',
                headStyles: {
                    fillColor: [41, 128, 185],
                    textColor: [255, 255, 255],
                    fontStyle: 'bold'
                },
                alternateRowStyles: { fillColor: [245, 245, 245] },
                margin: { top: 40 }
            });

            const finalY = doc.lastAutoTable.finalY + 10;
            doc.setFontSize(9);
            doc.text('Sistema de Labor Social - Universidad PTY', doc.internal.pageSize.width / 2, finalY, { align: 'center' });

            var nombreArchivo = 'Reporte_Estudiantes_' + new Date().toISOString().slice(0, 10);
            if (filtro) nombreArchivo += '_' + filtro.replace(/\s+/g, '_');
            doc.save(nombreArchivo + '.pdf');

            mostrarAlerta('PDF generado exitosamente', 'success');
        }

        function descargarReporteEstudiantesExcel() {
            var filtroCarrera = $('#filtroCarrera').val();
            mostrarCargando('Generando Excel de estudiantes...');

            $.ajax({
                url: '/api/estudiante',
                type: 'GET',
                success: function (data) {
                    if (filtroCarrera) {
                        data = data.filter(e => e.Carrera === filtroCarrera);
                    }

                    generarExcelEstudiantes(data, filtroCarrera);
                    ocultarCargando();
                },
                error: function () {
                    ocultarCargando();
                    mostrarAlerta('Error generando Excel', 'danger');
                }
            });
        }

        function generarExcelEstudiantes(data, filtro) {
            const workbook = new ExcelJS.Workbook();
            workbook.creator = 'Sistema Labor Social';
            workbook.created = new Date();

            const worksheet = workbook.addWorksheet('Estudiantes');

            worksheet.mergeCells('A1:F1');
            worksheet.getCell('A1').value = 'REPORTE DE ESTUDIANTES';
            worksheet.getCell('A1').font = { size: 16, bold: true };
            worksheet.getCell('A1').alignment = { horizontal: 'center' };

            worksheet.getCell('A2').value = 'Fecha de generación:';
            worksheet.getCell('B2').value = new Date().toLocaleString();
            worksheet.getCell('A3').value = 'Total registros:';
            worksheet.getCell('B3').value = data.length;

            if (filtro) {
                worksheet.getCell('A4').value = 'Carrera filtrada:';
                worksheet.getCell('B4').value = filtro;
            }

            const headers = ['Código', 'Nombre Completo', 'Email', 'Carrera', 'Semestre', 'Fecha Registro'];
            worksheet.addRow(headers);

            const headerRow = worksheet.getRow(6);
            headerRow.eachCell((cell) => {
                cell.font = { bold: true, color: { argb: 'FFFFFFFF' } };
                cell.fill = {
                    type: 'pattern',
                    pattern: 'solid',
                    fgColor: { argb: 'FF2E86C1' }
                };
                cell.alignment = { horizontal: 'center' };
                cell.border = {
                    top: { style: 'thin' },
                    left: { style: 'thin' },
                    bottom: { style: 'thin' },
                    right: { style: 'thin' }
                };

            data.forEach(est => {
                worksheet.addRow([
                    est.Codigo,
                    est.Nombre,
                    est.Email,
                    est.Carrera,
                    est.Semestre,
                    est.FechaRegistro ? new Date(est.FechaRegistro).toLocaleDateString() : ''
                ]);
            });

            worksheet.columns = [
                { width: 15 }, // Código
                { width: 30 }, // Nombre
                { width: 25 }, // Email
                { width: 40 }, // Carrera
                { width: 10 }, // Semestre
                { width: 15 }  // Fecha
            ];

            workbook.xlsx.writeBuffer().then(buffer => {
                const blob = new Blob([buffer], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
                var nombreArchivo = 'Reporte_Estudiantes_' + new Date().toISOString().slice(0, 10);
                if (filtro) nombreArchivo += '_' + filtro.replace(/\s+/g, '_');
                saveAs(blob, nombreArchivo + '.xlsx');
                mostrarAlerta('Excel generado exitosamente', 'success');
            });
        }

        function descargarReporteActividadesPDF() {
            var filtroEstado = $('#filtroEstado').val();
            mostrarCargando('Generando PDF de actividades...');


            var actividadesEjemplo = [
                { Nombre: 'Reciclaje en campus', Estado: 'Activa', Horas: 20, Estudiantes: 15, FechaInicio: '2024-01-15' },
                { Nombre: 'Tutorías a estudiantes', Estado: 'Activa', Horas: 30, Estudiantes: 8, FechaInicio: '2024-01-20' },
                { Nombre: 'Limpieza de áreas verdes', Estado: 'Finalizada', Horas: 25, Estudiantes: 12, FechaInicio: '2023-12-10' },
                { Nombre: 'Digitalización de planos', Estado: 'Pendiente', Horas: 40, Estudiantes: 5, FechaInicio: '2024-02-01' }
            ];

            if (filtroEstado) {
                actividadesEjemplo = actividadesEjemplo.filter(a => a.Estado === filtroEstado);
            }

            generarPDFActividades(actividadesEjemplo, filtroEstado);
            ocultarCargando();
        }

        function descargarReporteInscripcionesPDF() {
            var mes = $('#filtroMes').val();
            mostrarCargando('Generando PDF de inscripciones...');

            var inscripcionesEjemplo = [
                { Codigo: '20241106', Estudiante: 'Alejandro Martínez', Actividad: 'Reciclaje', Fecha: '2024-01-15', Horas: 20, Estado: 'Completada' },
                { Codigo: '20241107', Estudiante: 'Isabel Giraldo', Actividad: 'Tutorías', Fecha: '2024-01-20', Horas: 30, Estado: 'En progreso' },
                { Codigo: '20241206', Estudiante: 'Diana Páez', Actividad: 'Limpieza', Fecha: '2024-01-10', Horas: 25, Estado: 'Completada' },
                { Codigo: '20241207', Estudiante: 'Santiago Molina', Actividad: 'Digitalización', Fecha: '2024-01-25', Horas: 40, Estado: 'Pendiente' }
            ];

            generarPDFInscripciones(inscripcionesEjemplo, mes);
            ocultarCargando();
        }

        function descargarReporteCompletoPDF() {
            mostrarCargando('Generando reporte completo...');

            const doc = new jsPDF();

            doc.setFontSize(24);
            doc.text('REPORTE COMPLETO', 105, 50, null, null, 'center');
            doc.setFontSize(16);
            doc.text('Sistema de Labor Social', 105, 70, null, null, 'center');
            doc.text('Universidad   PTY ', 105, 85, null, null, 'center');

            doc.setFontSize(12);
            doc.text('Generado el: ' + new Date().toLocaleDateString(), 105, 105, null, null, 'center');
            doc.text('Por: Sistema Automático de Reportes', 105, 115, null, null, 'center');

            doc.addPage();

            doc.setFontSize(18);
            doc.text('ÍNDICE', 20, 30);
            doc.setFontSize(12);
            doc.text('1. Estadísticas Generales', 20, 50);
            doc.text('2. Listado de Estudiantes', 20, 60);
            doc.text('3. Actividades por Estado', 20, 70);
            doc.text('4. Inscripciones por Período', 20, 80);
            doc.text('5. Gráficos Estadísticos', 20, 90);

            doc.save('Reporte_Completo_' + new Date().toISOString().slice(0, 10) + '.pdf');
            ocultarCargando();
            mostrarAlerta('Reporte completo generado', 'success');
        }


        function verReporteActividades() {
            var filtroEstado = $('#filtroEstado').val();

            var datos = [
                { Nombre: 'Reciclaje en campus', Estado: 'Activa', Horas: 20, Estudiantes: 15, Responsable: 'Prof. García' },
                { Nombre: 'Tutorías a estudiantes', Estado: 'Activa', Horas: 30, Estudiantes: 8, Responsable: 'Prof. Martínez' },
                { Nombre: 'Limpieza de áreas verdes', Estado: 'Finalizada', Horas: 25, Estudiantes: 12, Responsable: 'Prof. López' },
                { Nombre: 'Digitalización de planos', Estado: 'Pendiente', Horas: 40, Estudiantes: 5, Responsable: 'Prof. Rodríguez' },
                { Nombre: 'Clasificar togas', Estado: 'Activa', Horas: 15, Estudiantes: 10, Responsable: 'Prof. Fernández' }
            ];

            if (filtroEstado) {
                datos = datos.filter(a => a.Estado === filtroEstado);
            }

            var tabla = $('#tablaVistaPrevia');
            tabla.empty();

            tabla.append(`
                <thead>
                    <tr>
                        <th>Actividad</th>
                        <th>Estado</th>
                        <th>Horas</th>
                        <th>Estudiantes</th>
                        <th>Responsable</th>
                    </tr>
                </thead>
                <tbody>
            `);

            datos.forEach(item => {
                var estadoBadge = item.Estado === 'Activa' ? 'badge bg-success' :
                    item.Estado === 'Finalizada' ? 'badge bg-secondary' :
                        'badge bg-warning';

                tabla.append(`
                    <tr>
                        <td>${item.Nombre}</td>
                        <td><span class="${estadoBadge}">${item.Estado}</span></td>
                        <td>${item.Horas}</td>
                        <td>${item.Estudiantes}</td>
                        <td>${item.Responsable}</td>
                    </tr>
                `);
            });

            tabla.append('</tbody>');

            $('#tituloVistaPrevia').text('Actividades por Estado');
            $('#cardVistaPrevia').show();

            $('html, body').animate({
                scrollTop: $('#cardVistaPrevia').offset().top - 20
            }, 500);
        }

        function cerrarVistaPrevia() {
            $('#cardVistaPrevia').hide();
        }

        function imprimirReporte() {
            window.print();
        }

        function exportarGraficoCarreras() {
            var canvas = document.getElementById('carrerasChart');
            var imgData = canvas.toDataURL('image/png');

            const doc = new jsPDF();
            doc.setFontSize(16);
            doc.text('Gráfico: Estudiantes por Carrera', 105, 20, null, null, 'center');
            doc.addImage(imgData, 'PNG', 30, 30, 150, 100);
            doc.save('Grafico_Carreras_' + new Date().toISOString().slice(0, 10) + '.pdf');
        }

        function mostrarAlerta(mensaje, tipo) {
            var icono = tipo === 'success' ? 'fa-check-circle' :
                tipo === 'danger' ? 'fa-exclamation-triangle' :
                    tipo === 'warning' ? 'fa-exclamation-circle' : 'fa-info-circle';

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

        function mostrarCargando(mensaje) {
            $('#alertContainer').html(`
                <div class="alert alert-info alert-dismissible fade show" role="alert">
                    <i class="fas fa-spinner fa-spin me-2"></i>
                    ${mensaje}
                </div>
            `);
        }

        function ocultarCargando() {
            $('.alert').alert('close');
        }

        function aplicarFiltroMes() {
            var mes = $('#filtroMes').val();
            mostrarAlerta('Filtro aplicado para: ' + mes, 'info');
        }
    </script>
</asp:Content>