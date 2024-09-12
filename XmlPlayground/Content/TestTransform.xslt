<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:ext="urn:ext-scripts"               
                xmlns:ns="https://sanctionslistservice.ofac.treas.gov/api/PublicationPreview/exports/ENHANCED_XML"
                exclude-result-prefixes="xsl ext ns">

  <xsl:output method="xml" indent="yes" encoding="UTF-8"/>

  <xsl:template match="/">
    <BlackList>
      <xsl:for-each select="ns:sanctionsData/ns:entities/ns:entity[ns:brabras/ns:test='abc']">
        <Entry>ABC</Entry>
      </xsl:for-each>
    </BlackList>
  </xsl:template>
</xsl:stylesheet>