---
kind: method
id: M:Autodesk.Revit.UI.RevitLinkUIUtils.ReportLinkLoadResults(Autodesk.Revit.DB.Document,System.Collections.Generic.IDictionary{System.String,Autodesk.Revit.DB.LinkLoadResult})
source: html/db7e41b0-bbb0-e8be-a431-be457be78c59.htm
---
# Autodesk.Revit.UI.RevitLinkUIUtils.ReportLinkLoadResults Method

This function reports any errors which were encountered
 when loading the Revit links represented by the given
 LinkLoadResult map.

## Syntax (C#)
```csharp
public static void ReportLinkLoadResults(
	Document doc,
	IDictionary<string, LinkLoadResult> loadResults
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document containing the links.
- **loadResults** (`System.Collections.Generic.IDictionary < String , LinkLoadResult >`) - A map from the display name of a link to the LinkLoadResult
 for that link.

## Remarks
If all links succeeded in loading, the function does
 nothing. If any links failed to load, this function
 will display the Unresolved References dialog, giving
 the user the option to open the Manage Links dialog
 to correct any problems. To ensure the dialog fits on the screen, Revit will
 only list up to ten link names. Additional links will
 be mentioned as, "And >number< additional links." This
 is the same behavior Revit's user interface uses.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

