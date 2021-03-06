<%@ Control Inherits="CuteEditor.EditorUtilityCtrl" Language="c#" AutoEventWireup="false" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<fieldset><legend>[[EditRow]]</legend>
	<table class="normal">
		<tr>
			<td colspan="2">
				<table class="normal" cellpadding="2" cellspacing="1">
					<tr>
						<td style="white-space:nowrap; width:80;" >[[Width]] :</td>
						<td><input type="text" id="inp_width" onkeypress="return CancelEventIfNotDigit()" size="14" /></td>
						<td>&nbsp;</td>
						<td style="white-space:nowrap; width:80;" >[[Height]] :</td>
						<td><input type="text" id="inp_height" onkeypress="return CancelEventIfNotDigit()" size="14" /></td>
					</tr>
					<tr>
						<td>[[Alignment]]:</td>
						<td>
							<select id="sel_align" style="width:90px">
								<option value="">[[NotSet]]</option>
								<option value="left">[[Left]]</option>
								<option value="center">[[Center]]</option>
								<option value="right">[[Right]]</option>
							</select>
						</td>
						<td></td>
						<td>[[vertical]] [[Alignment]]:</td>
						<td><select id="sel_valign" style="width:90px">
								<option value="">[[NotSet]]</option>
								<option value="top">[[Top]]</option>
								<option value="middle">[[Middle]]</option>
								<option value="baseline">[[Baseline]]</option>
								<option value="bottom">[[Bottom]]</option>
							</select>
						</td>
					</tr>
					<tr>
						<td>[[BackgroundColor]]:</td>
						<td><input autocomplete="off" size="14" type="text" id="inp_bgColor" oncolorpopup="this.selectedColor=value" style='behavior:url(Load.ashx?type=htc&file=ColorPicker.htc)'
								oncolorchange='inp_bgColor.value=this.selectedColor; inp_bgColor.style.backgroundColor=this.selectedColor' />
						</td>
						<td></td>
						<td>[[BorderColor]]:</td>
						<td><input autocomplete="off" size="14" type="text" id="inp_borderColor" oncolorpopup="this.selectedColor=value"
								style='behavior:url(Load.ashx?type=htc&file=ColorPicker.htc)' oncolorchange='inp_borderColor.value=this.selectedColor; inp_borderColor.style.backgroundColor=this.selectedColor' />
						</td>
					</tr>
					<tr>
						<td>[[BorderColorLight]]:</td>
						<td><input autocomplete="off" size="14" type="text" id="inp_borderColorLight" oncolorpopup="this.selectedColor=value"
								style='behavior:url(Load.ashx?type=htc&file=ColorPicker.htc)' oncolorchange='inp_borderColorLight.value=this.selectedColor; inp_borderColorLight.style.backgroundColor=this.selectedColor' />
						</td>
						<td></td>
						<td>[[BorderColorDark]]:</td>
						<td><input autocomplete="off" size="14" type="text" id="inp_borderColorDark" oncolorpopup="this.selectedColor=value"
								style='behavior:url(Load.ashx?type=htc&file=ColorPicker.htc)' oncolorchange='inp_borderColorDark.value=this.selectedColor; inp_borderColorDark.style.backgroundColor=this.selectedColor' />
						</td>
					</tr>
					<tr>
						<td>[[CssClass]]:</td>
						<td><input size="14" type="text" id="inp_class" /></td>
						<td></td>
						<td valign="middle" style="white-space:nowrap">[[ID]]:</td>
						<td><input type="text" id="inp_id" size="14" /></td>
					</tr>
					<tr>
						<td>[[Title]]:</td>
						<td colspan="4"><textarea id="inp_tooltip" rows="6" cols="53"></textarea></td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
</fieldset>
<script type="text/javascript" src="Load.ashx?type=dialogscript&file=Dialog_Tag_Tr.js"></script>
