---
kind: method
id: M:Autodesk.Revit.DB.Structure.IStructuralSectionsServer.StructuralSectionsUpdate(Autodesk.Revit.DB.Structure.StructuralSectionsServiceData)
source: html/fabbe13b-5e48-1b86-6cd4-07b0a505a953.htm
---
# Autodesk.Revit.DB.Structure.IStructuralSectionsServer.StructuralSectionsUpdate Method

The server's method that will be called when Revit User clicks the Section Type parameter's button in the family dialog.

## Syntax (C#)
```csharp
bool StructuralSectionsUpdate(
	StructuralSectionsServiceData data
)
```

## Parameters
- **data** (`Autodesk.Revit.DB.Structure.StructuralSectionsServiceData`) - The Section Type data.

## Returns
Indicates whether the section type parameter server is executed successfully.

## Remarks
The server provides UI way for Revit user to view and modify the detail data corresponding with the parameter value.
 The server may also modify the section type parameter value itself during the execution.
 The method should always return 'true' if the server is successfully executed, no matter whether the server changes anything.
 Return 'false' or if the server throws, indicates a failed case, all changes made by the server will be discarded.

