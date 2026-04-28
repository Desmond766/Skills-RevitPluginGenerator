---
kind: method
id: M:Autodesk.Revit.UI.FileDialog.IsValidFilterString(System.String)
source: html/c5d40df2-98ed-0620-85f3-95bb70c6adf6.htm
---
# Autodesk.Revit.UI.FileDialog.IsValidFilterString Method

Determines if the input string is acceptable as input for a FileDialog filter string.

## Syntax (C#)
```csharp
public static bool IsValidFilterString(
	string filterString
)
```

## Parameters
- **filterString** (`System.String`) - The filter string.

## Returns
True of the filter string meets the minimal requirements to be a valid filter string.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

