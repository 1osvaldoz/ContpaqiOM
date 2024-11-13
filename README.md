<h3>Prueba de Osvaldo Monzon</h3>
<strong>*****La cadena XML tiene que transformarse en Base64*****</strong>
<h4>El archivo XML que considerar lo siguiente</h4>
<ul>
    <li><strong>Comprobante tiene que ser el elemento root</strong>
    </li>
    <li><strong>Emisor:</strong> Hijo de <b>Comprobante</b>, con los siguientes especificaciones:
        <ul>
            <li><b>Nombre</b> (requerido): tipo:<b>string</b></li>
            <li><b>Rfc</b> (requerido): tipo <b>string</b></li>
        </ul>
    </li>
    <li><strong>Receptor:</strong> Hijo de de <b>Comprobante</b>, con los siguientes especificaciones:
        <ul>
            <li><b>Nombre</b> (requerido): tipo <b>string</b></li>
            <li><b>Rfc</b> (requerido): tipo <b>string</b></li>
        </ul>
    </li>
    <li><strong>Conceptos:</strong> Hijo de <b>Comprobante</b> que contiene elementos <b>Concepto</b>.
        <ul>
  <li><strong>Debe contener al menos 1 elemento de este tipo</strong> </li>
            <li><strong>Definicion del elemento Concepto:</strong>:
                <ul>
                    <li><b>NoIdentificacion</b> (requerido): tipo <b>string</b></li>
                    <li><b>ClaveProdServ</b> (requerido): tipo <b>Int</b></li>
                    <li><b>Descripcion</b> (requerido): tipo <b>string</b></li>
                    <li><b>ClaveUnidad</b> (requerido): tipo <b>string</b></li>
                    <li><b>ValorUnitario</b> (requerido): tipo <b>Decimal</b></li>
                    <li><b>Cantidad</b> (requerido): tipo <b>Float</b></li>
                    <li><b>Importe</b> (requerido): tipo <b>Decimal</b></li>
                    <li><b>ObjetoImp</b> (opcional): tipo <b>string</b></li>
                </ul>
            </li>
        </ul>
    </li>
    <li><strong>Impuestos:</strong> Hijo de <b>Comprobante</b> (opcional).
        <ul>
            <li><b>TotalImpuestosTrasladados</b> (opcional): tipo <b>Decimal</b></li>
            <li><b>TotalImpuestosRetenidos</b> (opcional): tipo <b>Decimal</b></li>
        </ul>
    </li>
</ul>
<h3>Ejemplo Valido</h3>
![image](https://github.com/user-attachments/assets/ce17da8f-aa2d-4a19-85f7-447b6f4d18bb)
