<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:ext="urn:ext-scripts"
                xmlns:ns="http://eu.europa.ec/fpi/fsd/export"
                exclude-result-prefixes="xsl ext ns">

  <xsl:output method="xml" indent="yes" encoding="UTF-8"/>

  <xsl:template match="/">
    <BlackList>
      <xsl:for-each select="ns:export/ns:sanctionEntity[ns:subjectType/@code='person']">

        <Entry>

          <xsl:choose>
            <xsl:when test="string-length(ns:birthdate/@birthdate) &gt; 0">
              <DateOfBirth>
                <xsl:value-of select="ns:birthdate/@birthdate"/>
              </DateOfBirth>
            </xsl:when>
          </xsl:choose>

          <Aliases>
            <xsl:for-each select="ns:nameAlias">
              <Alias>
                <xsl:value-of select="@wholeName"/>
              </Alias>
            </xsl:for-each>
          </Aliases>

          <ListedDateInfo>
            <xsl:value-of select="ns:regulation/@publicationDate"/>
          </ListedDateInfo>

        </Entry>
      </xsl:for-each>
    </BlackList>
  </xsl:template>
</xsl:stylesheet>