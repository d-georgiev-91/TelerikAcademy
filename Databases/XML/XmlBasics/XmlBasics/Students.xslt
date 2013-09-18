<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <body>
        <h1>University</h1>
        <table bgcolor="#E0E0E0" cellspacing="1" border="1">
          <tr bgcolor="#EEEEEE">
            <th>StudentName</th>
            <th>Sex</th>
            <th>BirthDate</th>
            <th>Phone</th>
            <th>Email</th>
            <th>Course</th>
            <th>Specialty</th>
            <th>FacultyN</th>
            <th>Exams</th>
          </tr>
          <xsl:for-each select="/students/student">
            <tr bgcolor="white">
              <td>
                <xsl:value-of select="name"/>
              </td>
              <td>
                <xsl:value-of select="sex"/>
              </td>
              <td>
                <xsl:value-of select="birth-date"/>
              </td>
              <td>
                <xsl:value-of select="phone"/>
              </td>
              <td>
                <xsl:value-of select="email"/>
              </td>
              <td>
                <xsl:value-of select="course"/>
              </td>
              <td>
                <xsl:value-of select="specialty"/>
              </td>
              <td>
                <xsl:value-of select="faculty-number"/>
              </td>
              <td>

                <xsl:for-each select="exams">
                  <table cellspacing="1" border="1">
                    <tr>
                      <th>Name</th>
                      <th>Tutor</th>
                      <th>Score</th>
                    </tr>
                    <tr>
                      <xsl:for-each select="exam">
                        <tr>
                          <td>
                            <xsl:value-of select="name"/>
                          </td>
                          <td>
                            <xsl:value-of select="tutor"/>
                          </td>
                          <td>
                            <xsl:value-of select="score"/>
                          </td>
                        </tr>
                      </xsl:for-each>
                    </tr>
                  </table>
                </xsl:for-each>

              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>