---
kind: method
id: M:Autodesk.Revit.DB.FamilySymbol.Activate
zh: 族类型、族符号
source: html/b4e09402-f6cd-3f48-d01e-ecb87375bac5.htm
---
# Autodesk.Revit.DB.FamilySymbol.Activate Method

**中文**: 族类型、族符号

Activates the symbol to ensure that its geometry is accessible.

## Syntax (C#)
```csharp
public void Activate()
```

## Remarks
Symbols that are not used in the document may be deactivated to conserve memory and regeneration time.
 When the symbol is inactive, its geometry is empty and should not be accessed.
 In order to access geometry of a symbol that is not active in the document, first check its IsActive 
 property. Note that until the document is regenerated, the newly activated symbol's geometry
 will still be empty.

