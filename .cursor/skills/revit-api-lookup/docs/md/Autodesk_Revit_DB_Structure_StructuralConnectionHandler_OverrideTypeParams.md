---
kind: property
id: P:Autodesk.Revit.DB.Structure.StructuralConnectionHandler.OverrideTypeParams
source: html/a856e3e4-892a-104a-d87c-aadf12887abe.htm
---
# Autodesk.Revit.DB.Structure.StructuralConnectionHandler.OverrideTypeParams Property

Allow or disallow connection's type parameters to be overridden.

## Syntax (C#)
```csharp
public bool OverrideTypeParams { get; set; }
```

## Remarks
When set to true, a set of instance parameters is created for this connection by copying the type parameter set and the user can change this instance parameters in order to make this connection different from the others of the same type.
 Any further modification on type parameters will not affect this instance (until the "override" is turned back off).
 When set to false the connection instance parameters are discarded and the type parameters are used again.
 The default value of this parameter is false.

