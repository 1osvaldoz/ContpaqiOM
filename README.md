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

```xml
<?xml version="1.0" encoding="UTF-8"?>
<Comprobante xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" Version="4.0" LugarExpedicion="44600" MetodoPago="PUE" FormaPago="EFE" TipoDeComprobante="I" Folio="478965" Moneda="MXN" Serie="MXN" Fecha="2024-05-28T12:35:00" Total="1868.72" SubTotal="1960.20" UUID="beda5db8-de6b-4531-8ed2-a09b33a76c07">
  <Emisor Nombre="XOCHILT CASAS CHAVEZ" Rfc="CACX7605101P8"/>
  <Receptor Nombre="MAQUINARIA INGENIERIA Y CONSTRUCCIONES DEL SURESTE SA DE CV" />
  <Conceptos>
    <Concepto NoIdentificacion="CONSUL778" ClaveProdServ="85121600" Descripcion="Servicios de gastroenterólogos" ClaveUnidad="E48" ValorUnitario="980.1" Cantidad="2" Importe="1960.20" ObjetoImp="02" />
  </Conceptos>
  <Impuestos TotalImpuestosRetenidos="405.11" TotalImpuestosTrasladados="313.63" />
</Comprobante>

```
<h3>Estructura del xsd</h3>

```xml
<?xml version="1.0" encoding="utf-8"?>
<!-- Created with Liquid Technologies Online Tools 1.0 (https://www.liquid-technologies.com) -->
<xs:schema xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" attributeFormDefault="unqualified" elementFormDefault="qualified" xmlns:xs="http://www.w3.org/2001/XMLSchema">
  <xs:element name="Comprobante">
    <xs:complexType>
      <xs:sequence>
        <xs:element name="Emisor">
          <xs:complexType>
            <xs:attribute name="Nombre" type="xs:string" use="required" />
            <xs:attribute name="Rfc" type="xs:string" use="required" />
          </xs:complexType>
        </xs:element>
        <xs:element name="Receptor">
          <xs:complexType>
            <xs:attribute name="Nombre" type="xs:string" use="required" />
            <xs:attribute name="Rfc" type="xs:string" use="required" />
          </xs:complexType>
        </xs:element>
        <xs:element name="Conceptos">
          <xs:complexType>
            <xs:sequence>
              <xs:element name="Concepto" minOccurs="1" maxOccurs="unbounded">
                <xs:complexType>
                  <xs:attribute name="NoIdentificacion" type="xs:string" use="required" />
                  <xs:attribute name="ClaveProdServ" type="xs:unsignedInt" use="required" />
                  <xs:attribute name="Descripcion" type="xs:string" use="required" />
                  <xs:attribute name="ClaveUnidad" type="xs:string" use="required" />
                  <xs:attribute name="ValorUnitario" type="xs:decimal" use="required" />
                  <xs:attribute name="Cantidad" type="xs:unsignedByte" use="required" />
                  <xs:attribute name="Importe" type="xs:decimal" use="required" />
                  <xs:attribute name="ObjetoImp" type="xs:string" use="optional" />
                </xs:complexType>
              </xs:element>
            </xs:sequence>
          </xs:complexType>
        </xs:element>
        <xs:element name="Impuestos" minOccurs="0" maxOccurs="1">
          <xs:complexType>
            <xs:attribute name="TotalImpuestosTrasladados" type="xs:decimal" use="optional" />
            <xs:attribute name="TotalImpuestosRetenidos" type="xs:decimal" use="optional" />
          </xs:complexType>
        </xs:element>
      </xs:sequence>
      <xs:attribute name="Version" type="xs:string" use="required" />
      <xs:attribute name="LugarExpedicion" type="xs:string" use="required" />
      <xs:attribute name="MetodoPago" type="xs:string" use="required" />
      <xs:attribute name="TipoDeComprobante" type="xs:string" use="required" />
      <xs:attribute name="FormaPago" type="xs:string" use="required" />
      <xs:attribute name="Folio" type="xs:string" use="required" />
      <xs:attribute name="Moneda" type="xs:string" use="required" />
      <xs:attribute name="Serie" type="xs:string" use="required" />
      <xs:attribute name="UUID" type="xs:string" use="required" />
      <xs:attribute name="Fecha" type="xs:dateTime" use="required" />
      <xs:attribute name="Total" type="xs:decimal" use="required" />
      <xs:attribute name="SubTotal" type="xs:decimal" use="required" />
    </xs:complexType>
  </xs:element>
</xs:schema>

```

