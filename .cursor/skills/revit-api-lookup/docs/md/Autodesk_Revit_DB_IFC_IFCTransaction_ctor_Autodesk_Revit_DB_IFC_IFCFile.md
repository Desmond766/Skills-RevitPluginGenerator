---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCTransaction.#ctor(Autodesk.Revit.DB.IFC.IFCFile)
source: html/1faf8e33-e93c-3916-94d7-def74b9ba92f.htm
---
# Autodesk.Revit.DB.IFC.IFCTransaction.#ctor Method

Instantiates a transaction object.

## Syntax (C#)
```csharp
public IFCTransaction(
	IFCFile file
)
```

## Parameters
- **file** (`Autodesk.Revit.DB.IFC.IFCFile`) - The IFC file for which this transaction is going to be used.

## Remarks
The transaction starts by creating a transaction object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

