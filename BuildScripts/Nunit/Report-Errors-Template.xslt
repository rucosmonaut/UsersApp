<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="text"/>
  <xsl:template match="/">
    <xsl:apply-templates/>
  </xsl:template>

  <xsl:variable name="newline">
    <xsl:text>&#xD;&#xA;</xsl:text>
  </xsl:variable>

  <xsl:variable name="break">
    <xsl:text>&#xD;&#xA;&#xD;&#xA;</xsl:text>
  </xsl:variable>

  <xsl:template match="test-run">
    
    <!-- Errors and Failures -->
    <xsl:if test="//test-case[failure]">
      <xsl:value-of select="concat('Errors and Failures',$break)"/>
    </xsl:if>
    <xsl:apply-templates select="//test-case[failure]"/>

  </xsl:template>

  <xsl:template match="test-case">
    <!-- Determine type of test-case for formatting -->
    <xsl:variable name="type">
      <xsl:choose>
        <xsl:when test="@result='Skipped'">
          <xsl:choose>
            <xsl:when test="@label='Ignored' or @label='Explicit'">
              <xsl:value-of select="@label"/>
            </xsl:when>
            <xsl:otherwise>
              <xsl:value-of select="'Other'"/>
            </xsl:otherwise>
          </xsl:choose>
        </xsl:when>
        <xsl:when test="@result='Failed'">
          <xsl:choose>
            <xsl:when test="@label='Error' or @label='Invalid'">
              <xsl:value-of select="@label"/>
            </xsl:when>
            <xsl:otherwise>
              <xsl:value-of select="'Failed'"/>
            </xsl:otherwise>
          </xsl:choose>
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="'Unknown'"/>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    
    <!-- Show details of test-cases either skipped or errored -->
    <xsl:value-of select="concat(position(), ') ', $type,' : ', @fullname, $newline, child::node()/message)"/>
    <xsl:choose>
      <xsl:when test="$type='Failed'">
        <xsl:value-of select="$newline"/>
      </xsl:when>
      <xsl:when test="$type='Error'">
        <xsl:value-of select="$newline"/>
      </xsl:when>
      <xsl:otherwise>
        <xsl:value-of select="$break"/>
      </xsl:otherwise>
    </xsl:choose>

    <!-- Stack trace for failures -->
    <xsl:if test="failure">
      <xsl:choose>
        <xsl:when test="$type='Failed'">
          <xsl:value-of select="concat(failure/stack-trace,$newline)"/>
        </xsl:when>
        <xsl:when test="$type='Error'">
          <xsl:value-of select="concat(failure/stack-trace,$break)"/>
        </xsl:when>
      </xsl:choose>
    </xsl:if>

  </xsl:template>

</xsl:stylesheet>
