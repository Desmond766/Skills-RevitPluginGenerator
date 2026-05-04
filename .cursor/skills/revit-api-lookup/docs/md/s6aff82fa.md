---
kind: type
id: T:Autodesk.Revit.DB.IFC.IFCTransaction
source: html/71896def-755f-1a91-90b0-37b6bb019265.htm
---
# Autodesk.Revit.DB.IFC.IFCTransaction

IFC transactions are context-like objects that guard any changes made to an IFC file.

## Syntax (C#)
```csharp
public class IFCTransaction : IDisposable
```

## Remarks
Any change to an IFC file can only be made while there is an active transaction
 open for that file. Changes do not become a part of the file until the
 active transaction is committed . Consequently, all
 changes made in a transaction can be rolled back 
 either explicitly or implicitly (by the destructor).

