<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="1.0" xmlns:xsl = "urn:students">

<xsl:template match="/">
  <html>
  <body>
  <h2>Students</h2>
  <table border="1">
    <tr bgcolor="#9acd32">
      <th>Name</th>
      <th>Gender</th>
      <th>Birth Date</th>
      <th>Phone Number</th>
      <th>Email</th>
      <th>University</th>
      <th>Specialty</th>
      <th>Faculty Number</th>
    </tr>
    <xsl:for-each select="students/student">
    <tr>
      <td><xsl:value-of select="name"/></td>
      <td><xsl:value-of select="gender"/></td>
      <td><xsl:value-of select="birthDate"/></td>
      <td><xsl:value-of select="phoneNumber"/></td>
      <td><xsl:value-of select="email"/></td>
      <td><xsl:value-of select="university"/></td>
      <td><xsl:value-of select="specialty"/></td>
      <td><xsl:value-of select="facultyNumber"/></td>
    </tr>
    </xsl:for-each>
  </table>
  </body>
  </html>
</xsl:template>

</xsl:stylesheet> 