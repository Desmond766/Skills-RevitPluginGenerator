---
kind: method
id: M:Autodesk.Revit.DB.BrowserOrganization.GetCurrentBrowserOrganizationForSchedules(Autodesk.Revit.DB.Document)
source: html/b32365b9-54d0-08b3-ee34-4a2cde7fa1d8.htm
---
# Autodesk.Revit.DB.BrowserOrganization.GetCurrentBrowserOrganizationForSchedules Method

Gets the BrowserOrganization that applies to the Schedules section of the project browser.

## Syntax (C#)
```csharp
public static BrowserOrganization GetCurrentBrowserOrganizationForSchedules(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Revit document from which to get the organization data.

## Returns
The BrowserOrganization for schedules, or null if no schedules sections exist

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

