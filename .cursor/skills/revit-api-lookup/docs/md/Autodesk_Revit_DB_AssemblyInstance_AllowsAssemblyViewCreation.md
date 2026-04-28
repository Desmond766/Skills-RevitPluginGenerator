---
kind: method
id: M:Autodesk.Revit.DB.AssemblyInstance.AllowsAssemblyViewCreation
source: html/63d643a0-7da2-eecb-d895-4e4603ede331.htm
---
# Autodesk.Revit.DB.AssemblyInstance.AllowsAssemblyViewCreation Method

Returns true if assembly views can be created for this Assembly Instance.

## Syntax (C#)
```csharp
public bool AllowsAssemblyViewCreation()
```

## Remarks
Assembly views are allowed when there are no assembly views for any instance of this type,
 or when the only existing assembly views belong to this instance

