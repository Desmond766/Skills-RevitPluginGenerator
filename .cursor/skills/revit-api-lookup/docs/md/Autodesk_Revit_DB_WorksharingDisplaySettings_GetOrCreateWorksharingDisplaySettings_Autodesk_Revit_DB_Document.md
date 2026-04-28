---
kind: method
id: M:Autodesk.Revit.DB.WorksharingDisplaySettings.GetOrCreateWorksharingDisplaySettings(Autodesk.Revit.DB.Document)
source: html/32871a69-64cd-adcb-7fd9-ae9a60f3615a.htm
---
# Autodesk.Revit.DB.WorksharingDisplaySettings.GetOrCreateWorksharingDisplaySettings Method

Returns the worksharing display settings for the document, creating
 new settings for the current user if necessary.

## Syntax (C#)
```csharp
public static WorksharingDisplaySettings GetOrCreateWorksharingDisplaySettings(
	Document doc
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document of interest.

## Returns
The worksharing display settings for the document.

## Remarks
Note that these settings are available even in models that are not
 workshared. This is to allow pre-configuring the display settings
 before enabling worksets so that they can be stored in template files.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - doc is not a project document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

