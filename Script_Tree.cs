//center bottom of the tree
//	%bottomPos - Center bottom of the tree. Should be a multiple of 0.5, +- 0.25 if 
function generateTree(%bottomPos, %bottomRadius, %bStemHeight, %stemRadius, %numLayers, %layerHeight, %layerSpace, %layerTrim)
{
	%bRad = %bottomRadius * 0.5;
	%lHeight = %layerHeight * 0.2;
	%lSpace = %layerSpace * 0.2;
	%sRad = %stemRadius * 0.5;
	
	%bottomCorner = VectorSub(%bottomPos, %bRad SPC %bRad SPC 0);
	%bottomBase = BlockFiller::chunkFill(%bottomCorner, %bottomRadius*2 SPC %bottomRadius*2 SPC %layerHeight);
	
	%bottomBase.createBricks();
	//%bottomBase.delete();

	%stemBottom = getWords(%bottomPos, 0, 1) SPC getWord(%bottomPos, 2) + %lHeight;
	%stemCorner = VectorSub(%stemBottom, %sRad SPC %sRad SPC 0);
	%firstStem = BlockFiller::chunkFill(%stemCorner, %stemRadius * 2 SPC %stemRadius * 2 SPC %bStemHeight);
	%firstStem.createBricks();
	//%firstStem.delete();
	%stemBottom = VectorAdd(%stemBottom, "0 0" SPC %bStemHeight * 0.2);
	
	%lRadius = (%numLayers) * %layerTrim;
	for (%l = 0; %l < %numLayers; %l++)
	{
		%lRad = %lRadius * 0.5;
		%layerCorner = VectorSub(%stemBottom, %lRad SPC %lRad SPC 0);
		%layer = BlockFiller::chunkFill(%layerCorner, %lRadius * 2 SPC %lRadius * 2 SPC %layerHeight);
		%layer.createBricks();
		//%layer.delete();
		%lRadius -= %layerTrim;
		%stemBottom = VectorAdd(%stemBottom, "0 0" SPC %lHeight);
		%stemCorner = VectorSub(%stemBottom, %sRad SPC %sRad SPC 0);
		%stem = BLockFiller::chunkFill(%stemCorner, %stemRadius * 2 SPC %stemRadius * 2 SPC %layerSpace);
		%stem.createBricks();
		//%stem.delete();
		%stemBottom = VectorAdd(%stemBottom, "0 0" SPC %lSpace);
	}
}
//generateTree("606.5 137.5 0", 20, 40*3, 6, 20, 5*3, 15*3, 10);