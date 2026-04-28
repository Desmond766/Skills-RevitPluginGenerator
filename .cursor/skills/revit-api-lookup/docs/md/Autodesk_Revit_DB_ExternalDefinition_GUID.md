---
kind: property
id: P:Autodesk.Revit.DB.ExternalDefinition.GUID
source: html/26015ea2-da14-405e-e3e6-0e12a0cfbaf7.htm
---
# Autodesk.Revit.DB.ExternalDefinition.GUID Property

Returns the GUID associated with the shared parameter definition.

## Syntax (C#)
```csharp
public virtual Guid GUID { get; }
```

## Remarks
Each shared parameter when created is issued a unique identifier. This identifier can then
be used at a later time to retrieve the parameter from the Element ensuring that the correct
parameter is always retrieved.

