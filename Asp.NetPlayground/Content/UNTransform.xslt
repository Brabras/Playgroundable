<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:ext="urn:ext-scripts"
                exclude-result-prefixes="xsl ext">

    <xsl:output method="xml" indent="yes" encoding="UTF-8"/>

    <xsl:template match="/">
        <BlackList>
            <xsl:for-each select="/CONSOLIDATED_LIST/INDIVIDUALS/INDIVIDUAL">
                <Entry>

                    <DateOfBirth>
                        <xsl:value-of select="INDIVIDUAL_DATE_OF_BIRTH/DATE"/>
                    </DateOfBirth>

                    <Aliases>
                        <Alias>
                            <xsl:value-of select="ext:FullName(THIRD_NAME, FIRST_NAME, SECOND_NAME, FOURTH_NAME)"/>
                        </Alias>
                        <xsl:for-each select="INDIVIDUAL_ALIAS">
                            <xsl:if test="string-length(ALIAS_NAME) &gt; 0">
                                <Alias>
                                    <xsl:value-of select="ALIAS_NAME"/>
                                </Alias>
                            </xsl:if>
                        </xsl:for-each>
                    </Aliases>

                    <ListedDateInfo>
                        <xsl:value-of select="LISTED_ON"/>
                    </ListedDateInfo>

                </Entry>
            </xsl:for-each>
        </BlackList>
    </xsl:template>
</xsl:stylesheet>