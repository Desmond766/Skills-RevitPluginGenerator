---
kind: property
id: P:Autodesk.Revit.DB.IFC.IFCImportOptions.RevitLinkFileName
source: html/34cbbeb3-4be9-42c9-bc0c-9e411c2d3184.htm
---
# Autodesk.Revit.DB.IFC.IFCImportOptions.RevitLinkFileName Property

The full path of the intermediate Revit file created during a previous link action.
 This is used during "Reload From" to determine the path to the previous generated Revit file.

## Syntax (C#)
```csharp
public string RevitLinkFileName { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

