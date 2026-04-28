---
kind: method
id: M:Autodesk.Revit.DB.BrowserOrganization.GetCurrentBrowserOrganizationForSheets(Autodesk.Revit.DB.Document)
source: html/62479943-c356-7d0a-7ca4-b5e4db785948.htm
---
# Autodesk.Revit.DB.BrowserOrganization.GetCurrentBrowserOrganizationForSheets Method

Gets the BrowserOrganization that applies to the Sheets section of the project browser.

## Syntax (C#)
```csharp
public static BrowserOrganization GetCurrentBrowserOrganizationForSheets(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Revit document from which to get the organization data.

## Returns
The BrowserOrganization for sheets, or null if no sheets exist.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

