<?xml version='1.0'?>
<!DOCTYPE xsl:stylesheet [
<!ENTITY CDA-Stylesheet
    '-//HL7//XSL HL7 V1.1 CDA Stylesheet: 2000-08-03//EN'>
]>
<xsl:stylesheet version='1.0'
  xmlns:xsl='http://www.w3.org/1999/XSL/Transform'>
  <xsl:output method='html' indent='yes' version='4.01'
    doctype-public='-//W3C//DTD HTML 4.01//EN'/>
  <!-- If 'true', XHTML document uses JavaScript for added
       functionality, such as pop-up windows and information-
       hiding.
       Otherwise, XHTML document does not use JavaScript. -->
  <xsl:param name="useJavaScript">true</xsl:param>
  
  <xsl:template match='/HL7v2xConformanceProfile'>
    <html>
      <head>
        <meta name='Generator' content='HL7-Message-Profile-Stylesheet;'/>
        <link rel="stylesheet" type="text/css" title="Default" href="./css/default.css" />
        <xsl:comment>
          do NOT edit this HTML directly, it was generated
          via an XSLT transformation from the original Level 1
          document.
        </xsl:comment>
        
        <script type="text/javascript">
          <xsl:text>
            var ol_shadow = 1;var ol_shadowcolor = '#222277';
            var ol_shadowopacity = 60;
          </xsl:text>            
        </script>
        <script type="text/javascript" src="./common/js/overlib.js" />          
        <title>
          Message Profile of type 
          <xsl:value-of select='@ProfileType'/> 
          version
          <xsl:value-of select='@HL7Version'/>
          
        </title>
        
        
        <!-- Add Javascript code to make the collapseable boxes work -->
        <xsl:if test="normalize-space(translate($useJavaScript,'TRUE','true'))='true'">
          <xsl:call-template name="PrintJSCode">
            <xsl:with-param name="code">
              <xsl:call-template name="DocumentJSCode"/>
            </xsl:with-param>
          </xsl:call-template>
        </xsl:if>
      </head>
      <body onload='show_hide_init();' >
        <div id="overDiv" style="position:absolute; visibility:hidden; z-index:10000;"></div>
        <div id="banner">
    
        </div>        
        <div id="container">
         <div id="navigation">
         <form>
            <input type="button" value="Back" onClick="history.go(-1);return true;"/> 
          </form>
        </div>
       <div id="content">
          <xsl:apply-templates select='HL7v2xStaticDef'/>
        </div>
      </div>
        <div id="footer">
          <p><a href="mailto:eric.poiseau@inria.fr">Webmaster</a> <br/>Consultation date:  <br/>Last modified: </p>
        </div>
      </body>
    </html>
  </xsl:template>

      <xsl:template  match='HL7v2xStaticDef'>
        <div class='segment'>
          <h1>HL7 Message Profiles : <strong>
          <xsl:value-of select='@MsgType'/>  
          <xsl:text>:</xsl:text>
          <xsl:value-of select='@EventType'/>
        </strong></h1> 
          <table width="100%">
            <xsl:apply-templates select='Segment|SegGroup'/>
          </table>
        </div>
      </xsl:template>

      <xsl:template match='SegGroup'>
        <xsl:variable name="min" select="@Min"/>
        <xsl:variable name="max" select="@Max"/>
        <tr>
          <td colspan="4" >
            <div class='group'>
              <table width="100%">
                <tr>
                  <td >
                    <xsl:if test='$min=0'> [ </xsl:if>
                    <xsl:if test='$max="*"'> { </xsl:if>
                    <xsl:if test='substring(@LongName, 4, 1) != "." or substring(@LongName, 8, 1) != "."'>                      
                    <strong>
                      <xsl:value-of select='@LongName'/> 
                    </strong>
                  </xsl:if>
                </td>

              </tr>
              <xsl:apply-templates select='Segment|SegGroup'/>
              <tr>
                <td>
                  <xsl:if test='$max="*"'> } </xsl:if>
                  <xsl:if test='$min=0'> ] </xsl:if>
                </td>
              </tr>
            </table>
          </div>          
        </td>
      </tr>
    </xsl:template>



      <xsl:template match='Segment'>
        <xsl:variable name="min" select="@Min"/>
        <xsl:variable name="max" select="@Max"/>
        <xsl:variable name="uid" select="concat(@Name, generate-id ())"/>
        <xsl:variable name="buttonID" select="concat($uid, '_button')"/>
        <xsl:variable name='segmentnumber' select="1"/>
        <tr>
          <td>
            <xsl:if test='$min=0'> [ </xsl:if>
            <xsl:if test='$max="*"'> { </xsl:if>
            <img src="./images/expand.gif" id="{$buttonID}" class="control" onclick="switchState('{$uid}'); return false;" style="display: none"/>
            <xsl:text> </xsl:text>
            <xsl:value-of select='@Name'/>  
            <xsl:if test='$max="*"'> } </xsl:if>
            <xsl:if test='$min=0'> ] </xsl:if>
          </td>
        </tr>
        <tr>
          <td colspan="4">
            <div id="{$uid}" class="box3">
              <xsl:value-of select='@Name'/> :   
              <xsl:value-of select='@LongName'/> 
              <table width="100%">
                <tr>
                  <th colspan="2">Field</th>
                  <th>Name</th>
                  <th>Datatype</th>
                  <th>Length</th>
                  <th>Usage</th>
                  <th>Card.</th>
                </tr>
                <xsl:apply-templates select='Field'/>
              </table>         
            </div>  
          </td>
        </tr>

      </xsl:template>

      <xsl:template match='Component' >
        <xsl:variable name="table" select="@Table"/>
       <tr>
          <td>
            <xsl:number value="position()" format="1" />
          </td>
          <td>
            <xsl:value-of select='@Name'/>
          </td>
          <td>
            <xsl:value-of select='@Datatype'/>
          </td>
          <td>
            <xsl:value-of select='@Length'/>
          </td>
          <td>
              <xsl:value-of select='@Usage'/>
         </td>
          <td>
             <xsl:value-of select='$table'/>
        </td>
        </tr> 
      </xsl:template>
      
      <xsl:template name='Field' match='Field'>
        <xsl:variable name="uid" select="concat(@Datatype, generate-id ())"/>
        <xsl:variable name="buttonID" select="concat($uid, '_button')"/>

        <tr>
          <xsl:if test="Component">
            <td>
              <img src="./images/expand.gif" id="{$buttonID}" class="control" onclick="switchState('{$uid}'); return false;" style="display: none"/>           
            </td>
          </xsl:if>
          <xsl:if test="not(Component)">
            <td>           
          </td>
        </xsl:if>
        <td>
          <xsl:number value="position()" format="1" />
          </td>
          <td>
            <xsl:value-of select='@Name'/>
          </td>
          <td>
            <xsl:value-of select='@Datatype'/>
          </td>
          <td>
            <xsl:value-of select='@Length'/>
          </td>
          <td>
            <xsl:value-of select='@Usage'/>
          </td>
          <td>
            <xsl:text>[</xsl:text>
            <xsl:value-of select='@Min'/>
            <xsl:text>..</xsl:text>
            <xsl:value-of select='@Max'/>
            <xsl:text>]</xsl:text>
          </td>
        </tr>

        <xsl:if test="Component">
          <tr>
            <td colspan="6">
              <div id="{$uid}" class="box2">
                <table width="100%" >
                  <tr>
                    <th>Field</th>
                    <th>Name</th>
                    <th>Datatype</th>
                    <th>Length</th>
                    <th>Usage</th>
                    <th>Table</th>
                  </tr>
                  <xsl:apply-templates select='Component'/>
                </table>         
              </div>  
            </td>
          </tr>
        </xsl:if>

      </xsl:template>
  


      
      <!-- 
           Java Script code required by the entire HTML document.
           -->
      
      <xsl:template name="getSegmentName" >
        <xsl:for-each select= 'Segment'>
          <xsl:text>, </xsl:text>
          <xsl:text>'</xsl:text>
          <xsl:value-of select='@Name'/>     
          <xsl:text>'</xsl:text>
        </xsl:for-each>
      </xsl:template>
      
      <xsl:template name="getGroupSegments" >
        <xsl:for-each select= 'Segment'>
          <xsl:text>, </xsl:text>
          <xsl:text>'</xsl:text>
          <xsl:value-of select='@Name'/>     
          <xsl:text>'</xsl:text>
        </xsl:for-each>
      </xsl:template>
      
      <xsl:template name="scBoxes"  >
        <!-- Get all IDs of XML Instance Representation boxes
             and place them in an array. -->
        <xsl:text>
          /* IDs of XML Instance Representation boxes */
        </xsl:text>
        <xsl:text>var scBoxes = new Array('void' </xsl:text>
        <xsl:for-each select= '/descendant::*'>
          <xsl:for-each select= 'Segment|SegGroup'>
            <xsl:text>, </xsl:text>
            <xsl:text>'</xsl:text>
            <xsl:variable name="uid" select="concat(@Name, generate-id ())"/>
            <xsl:value-of select='$uid'/>     
            <xsl:text>'</xsl:text>
          </xsl:for-each>
           <xsl:for-each select= 'Field'>
            <xsl:text>, </xsl:text>
            <xsl:text>'</xsl:text>
            <xsl:variable name="uid" select="concat(@Datatype, generate-id ())"/>
            <xsl:value-of select='$uid'/>     
            <xsl:text>'</xsl:text>
          </xsl:for-each>
       </xsl:for-each>
        <xsl:text>);</xsl:text>
      </xsl:template>
      
      <xsl:template name="DocumentJSCode"  >
        <xsl:call-template name="scBoxes"/>
        
        <!-- Functions -->
        <xsl:text>

/**
 * Can get the ID of the button controlling
 * a collapseable box by concatenating
 * this string onto the ID of the box itself.
 */
var B_SFIX = "_button";

/**
 * Counter of documentation windows
 * Used to give each window a unique name
 */
var windowCount = 0;

  /**
  * Initialises the state of the HTML page.
  */
  function show_hide_init() {
  var obj = getElementObject("globalControls");
  if (obj != null) {
  obj.style.display="block";
  }
  obj = getElementObject("printerControls");
  if (obj != null) {
    obj.style.display="inline";
  }
  //  expandAll(xiBoxes);
  collapseAll(scBoxes);
  //  viewControlButtons(xiBoxes);
  viewControlButtons(scBoxes);
  }


/**
 * Returns an element in the current HTML document.
 * 
 * @param elementID Identifier of HTML element
 * @return               HTML element object
 */
function getElementObject(elementID) {
    var elemObj = null;
    if (document.getElementById) {
        elemObj = document.getElementById(elementID);
    }
    return elemObj;
}             

/**
 * Closes a collapseable box.
 * 
 * @param boxObj       Collapseable box
 * @param buttonObj Button controlling box
 */
function closeBox(boxObj, buttonObj) {
  if (boxObj == null || buttonObj == null) {
     // Box or button not found
  } else {
     // Change 'display' CSS property of box
     boxObj.style.display="none";

     // Change text of button 
     if (boxObj.style.display=="none") {
          buttonObj.src="./images/collapse.gif";
        buttonObj.value="+";
     }
  }
}

/**
 * Opens a collapseable box.
 * 
 * @param boxObj       Collapseable box
 * @param buttonObj Button controlling box
 */
function openBox(boxObj, buttonObj) {
  if (boxObj == null || buttonObj == null) {
     // Box or button not found
  } else {
     // Change 'display' CSS property of box
     boxObj.style.display="block";

     // Change text of button
     if (boxObj.style.display=="block") {
          buttonObj.src="./images/expand.gif";
        buttonObj.value="-";
     }
  }
}

/**
 * Sets the state of a collapseable box.
 * 
 * @param boxID Identifier of box
 * @param open If true, box is "opened",
 *             Otherwise, box is "closed".
 */
function setState(boxID, open) {
  var boxObj = getElementObject(boxID);
  var buttonObj = getElementObject(boxID+B_SFIX);
  if (boxObj == null || buttonObj == null) {
     // Box or button not found
  } else if (open) {
     openBox(boxObj, buttonObj);
     // Make button visible
     buttonObj.style.display="inline";
  } else {
     closeBox(boxObj, buttonObj);
     // Make button visible
     buttonObj.style.display="inline";
  }
}

/**
 * Switches the state of a collapseable box, e.g.
 * if it's opened, it'll be closed, and vice versa.
 * 
 * @param boxID Identifier of box
 */
function switchState(boxID) {
  var boxObj = getElementObject(boxID);
  var buttonObj = getElementObject(boxID+B_SFIX);
  if (boxObj == null || buttonObj == null) {
     // Box or button not found
  } else if (boxObj.style.display=="none") {
     // Box is closed, so open it
     openBox(boxObj, buttonObj);
  } else if (boxObj.style.display=="block") {
     // Box is opened, so close it
     closeBox(boxObj, buttonObj);
  }
}

/**
 * Closes all boxes in a given list.
 * 
 * @param boxList Array of box IDs
 */
function collapseAll(boxList) {
  var idx;
  for (idx = 0; idx &lt; boxList.length; idx++) {
     var boxObj = getElementObject(boxList[idx]);
     var buttonObj = getElementObject(boxList[idx]+B_SFIX);
     closeBox(boxObj, buttonObj);
  }
}

/**
 * Open all boxes in a given list.
 * 
 * @param boxList Array of box IDs
 */
function expandAll(boxList) {
  var idx;
  for (idx = 0; idx &lt; boxList.length; idx++) {
     var boxObj = getElementObject(boxList[idx]);
     var buttonObj = getElementObject(boxList[idx]+B_SFIX);
     openBox(boxObj, buttonObj);
  }
}

/**
 * Makes all the control buttons of boxes appear.
 * 
 * @param boxList Array of box IDs
 */
function viewControlButtons(boxList) {
    var idx;
    for (idx = 0; idx &lt; boxList.length; idx++) {
        buttonObj = getElementObject(boxList[idx]+B_SFIX);
        if (buttonObj != null) {
            buttonObj.style.display = "inline";
        }
    }
}

/**
 * Makes all the control buttons of boxes disappear.
 * 
 * @param boxList Array of box IDs
 */
function hideControlButtons(boxList) {
    var idx;
    for (idx = 0; idx &lt; boxList.length; idx++) {
        buttonObj = getElementObject(boxList[idx]+B_SFIX);
        if (buttonObj != null) {
            buttonObj.style.display = "none";
        }
    }
}

/**
 * Sets the page for either printing mode
 * or viewing mode. In printing mode, the page
 * is made to be more readable when printing it out.
 * In viewing mode, the page is more browsable.
 *
 * @param isPrinterVersion If true, display in
 *                                 printing mode; otherwise, 
 *                                 in viewing mode
 */
function displayMode(isPrinterVersion) {
    var obj;
    if (isPrinterVersion) {
        // Hide global control buttons
        obj = getElementObject("globalControls");
        if (obj != null) {
            obj.style.visibility = "hidden";
        }
        // Hide Legend
        obj = getElementObject("legend");
        if (obj != null) {
            obj.style.display = "none";
        }
        obj = getElementObject("legendTOC");
        if (obj != null) {
            obj.style.display = "none";
        }
        // Hide Glossary
        obj = getElementObject("glossary");
        if (obj != null) {
            obj.style.display = "none";
        }
        obj = getElementObject("glossaryTOC");
        if (obj != null) {
            obj.style.display = "none";
        }

   
        // Expand all Schema Component Representation tables
        expandAll(scBoxes);

        // Hide Control buttons
        hideControlButtons(scBoxes);
    } else {
        // View global control buttons
        obj = getElementObject("globalControls");
        if (obj != null) {
            obj.style.visibility = "visible";
        }
        // View Legend
        obj = getElementObject("legend");
        if (obj != null) {
            obj.style.display = "block";
        }
        obj = getElementObject("legendTOC");
        if (obj != null) {
            obj.style.display = "block";
        }
        // View Glossary
        obj = getElementObject("glossary");
        if (obj != null) {
            obj.style.display = "block";
        }
        obj = getElementObject("glossaryTOC");
        if (obj != null) {
            obj.style.display = "block";
        }

    
        // Collapse all Schema Component Representation tables
        collapseAll(scBoxes);

        // View Control buttons
        viewControlButtons(scBoxes);
    }
}

/**
 * Opens up a window displaying the documentation
 * of a schema component in the XML Instance
 * Representation table.
 * 
 * @param compDesc      Description of schema component 
 * @param compName      Name of schema component 
 * @param docTextArray Array containing the paragraphs 
 *                           of the new document
 */
function viewDocumentation(compDesc, compName, docTextArray) {
  var width = 400;
  var height = 200;
  var locX = 100;
  var locY = 200;

  /* Generate content */
  var actualText = "&lt;html>";
  actualText += "&lt;head>&lt;title>";
  actualText += compDesc;
  if (compName != '') {
     actualText += ": " + compName;
  }
  actualText += "&lt;/title>&lt;/head>";
  actualText += "&lt;body bgcolor=\"#FFFFEE\">";
  // Title
  actualText += "&lt;p style=\"font-family: Arial, sans-serif; font-size: 12pt; font-weight: bold; letter-spacing:1px;\">";
  actualText += compDesc;
  if (compName != '') {
     actualText += ": &lt;span style=\"color:#006699\">" + compName + "&lt;/span>";
  }
  actualText += "&lt;/p>";
  // Documentation
  var idx;
  for (idx = 0; idx &lt; docTextArray.length; idx++) {
     actualText += "&lt;p style=\"font-family: Arial, sans-serif; font-size: 10pt;\">" + docTextArray[idx] + "&lt;/p>";
  }
  // Link to close window
  actualText += "&lt;a href=\"javascript:void(0)\" onclick=\"window.close();\" style=\"font-family: Arial, sans-serif; font-size: 8pt;\">Close&lt;/a>";
  actualText += "&lt;/body>&lt;/html>";

  /* Display window */
  windowCount++;
  var docWindow = window.open("", "documentation"+windowCount, "toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable,alwaysRaised,dependent,titlebar=no,width="+width+",height="+height+",screenX="+locX+",left="+locX+",screenY="+locY+",top="+locY);
  docWindow.document.write(actualText);
}
</xsl:text>
</xsl:template>

   <!--
     Prints out JavaScript code.
     NOTE: Javascript code is placed within comments to make it
     work with current browsers. In strict XHTML, JavaScript code 
     should be placed within CDATA sections. However, most
     browsers generate a syntax error if the page contains 
     CDATA sections. Placing Javascript code within comments
     means that the code cannot contain two dashes.
     Param(s):
            code (Result Tree Fragment) required
                Javascript code
  -->
   <xsl:template name="PrintJSCode">
      <xsl:param name="code"/>

      <script type="text/javascript">
         <!-- If browsers start supporting CDATA sections, 
              uncomment the following piece of code. -->
         <!-- <xsl:text disable-output-escaping="yes">
&lt;![CDATA[
</xsl:text> -->
         <!-- If browsers start supporting CDATA sections, 
              remove the following piece of code. -->
         <xsl:text disable-output-escaping="yes">
&lt;!--
</xsl:text>

         <xsl:value-of select="$code" disable-output-escaping="yes"/>
         <!-- If browsers start supporting CDATA sections, 
              remove the following piece of code. -->
         <xsl:text disable-output-escaping="yes">
// --&gt;
</xsl:text>
         <!-- If browsers start supporting CDATA sections, 
              uncomment the following piece of code. -->
         <!-- <xsl:text disable-output-escaping="yes">
]]&gt;
</xsl:text> -->
      </script>
   </xsl:template>

</xsl:stylesheet>
