---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceReference.GetResourceShortDisplayName
source: html/f2573abd-b662-1c0c-0005-3bcee6649877.htm
---
# Autodesk.Revit.DB.ExternalResourceReference.GetResourceShortDisplayName Method

Gets the short display name of the external resource.

## Syntax (C#)
```csharp
public string GetResourceShortDisplayName()
```

## Returns
The short display name of the external resource.

## Remarks
For an external resource, such as a Rvt Link loaded from an external server, which has a full display path
 such as "My Server://Nested/Nested_1.rvt", this function returns "Nested_1.rvt".
 For an external resource, such as a Rvt Link loaded from the "built-in" server, which has a full display path
 such as "c:\LocalLinks\Link_1.rvt", this function returns "Link_1.rvt".

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The ExternalResourceReference (this ExternalResourceReference) is has no valid display path.

