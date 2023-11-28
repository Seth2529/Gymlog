// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


let table = new DataTable('#tabela-pessoas', {
    language: {
        url: '//cdn.datatables.net/plug-ins/1.13.7/i18n/pt-BR.json',
    },
});

$('.close-alert').click(function () {
    $('.alert').hide('hide');
});

setTimeout(function () {
    $('.alert').fadeOut("slow", function () {
        $(this).alert('close');
    })   
},5000
)