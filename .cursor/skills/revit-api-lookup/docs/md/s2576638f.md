---
kind: property
id: P:Autodesk.Revit.DB.FamilyManager.Parameter(System.Guid)
zh: 参数、共享参数
source: html/11dc4a23-df9b-6574-3e4d-c4c03623856c.htm
---
# Autodesk.Revit.DB.FamilyManager.Parameter Property

**中文**: 参数、共享参数

Obtains the parameter of this type with a given GUID for a shared parameter.

## Syntax (C#)
```csharp
public FamilyParameter this[
	Guid guid
] { get; }
```

## Parameters
- **guid** (`System.Guid`)

## Remarks
Returns Nothing nullptr a null reference ( Nothing in Visual Basic) if the parameter is not found. This method is used to retrieve a family parameter 
for a known shared parameter. When a shared parameter is created it is assigned a Guid 
which will not change. This guid can be used to retrieve the piece of data from the
element at a later time.

