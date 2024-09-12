<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:ext="urn:ext-scripts"
                xmlns:ns="https://sanctionslistservice.ofac.treas.gov/api/PublicationPreview/exports/ENHANCED_XML"
                exclude-result-prefixes="xsl ext ns">

  <xsl:output method="xml" indent="yes" encoding="UTF-8"/>

  <xsl:template match="/">
    <BlackList>
      <xsl:for-each select="ns:sanctionsData/ns:entities/ns:entity[ns:generalInfo/ns:entityType='Individual']">

        <Entry>

          <xsl:choose>
            <xsl:when test="string-length(ns:features/ns:feature[ns:type='Birthdate']) &gt; 0">
              <DateOfBirth>
                <xsl:value-of select="ns:features/ns:feature[ns:type='Birthdate']/ns:value"/>
              </DateOfBirth>
            </xsl:when>
          </xsl:choose>

          <Aliases>
            <xsl:for-each select="ns:names/ns:name/ns:translations/ns:translation">
              <Alias>
                <xsl:value-of select="concat(ns:formattedLastName, ' ', ns:formattedFirstName)"/>
              </Alias>
            </xsl:for-each>
          </Aliases>

          <ListedDateInfo>
            <xsl:variable name="listName" select="ns:sanctionsLists/ns:sanctionsList"/>
            <xsl:variable name="listedDate" select="ns:sanctionsLists/ns:sanctionsList/@datePublished"/>
            <xsl:variable name="legalAuthority" select="ns:legalAuthorities/ns:legalAuthority"/>

            <xsl:value-of select="concat( $listName, ' ', $legalAuthority, ' ', $listedDate)"/>
          </ListedDateInfo>

        </Entry>
      </xsl:for-each>
    </BlackList>
  </xsl:template>
</xsl:stylesheet>