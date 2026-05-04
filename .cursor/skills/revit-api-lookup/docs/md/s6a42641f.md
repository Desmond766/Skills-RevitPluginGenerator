---
kind: method
id: M:Autodesk.Revit.Creation.ItemFactoryBase.NewFamilyInstances2(System.Collections.Generic.List{Autodesk.Revit.Creation.FamilyInstanceCreationData})
source: html/6ce99315-7b3d-6e29-73da-eb701b9dd064.htm
---
# Autodesk.Revit.Creation.ItemFactoryBase.NewFamilyInstances2 Method

Creates Family instances within the document.

## Syntax (C#)
```csharp
public ICollection<ElementId> NewFamilyInstances2(
	List<FamilyInstanceCreationData> dataList
)
```

## Parameters
- **dataList** (`System.Collections.Generic.List < FamilyInstanceCreationData >`) - A list of FamilyInstanceCreationData which wraps the creation arguments of the families to be created.

## Returns
If the creation is successful, a set of ElementIds which contains the Family instances should be returned, otherwise the exception will be thrown.

## Remarks
Note: ForbiddenForDynamicUpdateException might be thrown during a dynamic update if the inserted instance establishes a mutual dependency with another structure. Note: if the created family instance includes nested instances, the API framework will automatically regenerate 
the document during this method call.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - If FamilyInstanceCreationData's 'curve' or 'symbol' member is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - If regeneration fails at the end of the batch creation.

