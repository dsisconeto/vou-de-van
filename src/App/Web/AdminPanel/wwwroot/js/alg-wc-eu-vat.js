/**
 * alg-wc-eu-vat.js
 *
 * @version 1.1.0
 * @since   1.0.0
 * @author  Algoritmika Ltd.
 * @todo    [dev] replace `billing_eu_vat_number` and `billing_eu_vat_number_field` with `alg_wc_eu_vat_get_field_id()`
 * @todo    [dev] (maybe) code refactoring
 */

var _ajax_object = ajax_object;

jQuery( function( $ ) {

	// Setup before functions
	var inputTimer;               // timer identifier
	var doneInputInterval = 1000; // time in ms
	var vatInput          = $('input[name="billing_eu_vat_number"]');
	var vatParagraph      = $('p[id="billing_eu_vat_number_field"]');

	// Add progress text
	if ('yes'==_ajax_object.add_progress_text) {
		vatParagraph.append('<div id="alg_wc_eu_vat_progress"></div>');
		var progressText = $('div[id="alg_wc_eu_vat_progress"]');
	}

	// Initial validate
	validateVat();

	// On input, start the countdown
	vatInput.on('input', function() {
		clearTimeout(inputTimer);
		inputTimer = setTimeout(validateVat, doneInputInterval);
	});

	// On country change - re-validate
	$('#billing_country').on('change',validateVat);

	// Validate VAT
	function validateVat() {
		vatParagraph.removeClass('woocommerce-invalid');
		vatParagraph.removeClass('woocommerce-validated');
		var vatNumberToCheck = vatInput.val();
		if (''!=vatNumberToCheck) {
			// Validating EU VAT Number through AJAX call
			if ('yes'==_ajax_object.add_progress_text) {
				progressText.text(_ajax_object.progress_text_validating);
			}
			var data = {
				'action': 'alg_wc_eu_vat_validate_action',
				'alg_wc_eu_vat_to_check': vatNumberToCheck,
				'billing_country': $('#billing_country').val(),
			};
			$.ajax({
				type: "POST",
				url: _ajax_object.ajax_url,
				data: data,
				success: function(response) {
					if ('1'==response) {
						vatParagraph.addClass('woocommerce-validated');
						if ('yes'==_ajax_object.add_progress_text) {
							progressText.text(_ajax_object.progress_text_valid);
						}
					} else if ('0'==response) {
						vatParagraph.addClass('woocommerce-invalid');
						if ('yes'==_ajax_object.add_progress_text) {
							progressText.text(_ajax_object.progress_text_not_valid);
						}
					} else {
						vatParagraph.addClass('woocommerce-invalid');
						if ('yes'==_ajax_object.add_progress_text) {
							progressText.text(_ajax_object.progress_text_validation_failed);
						}
					}
					$('body').trigger('update_checkout');
				},
			});
		} else {
			// VAT input is empty
			if ('yes'==_ajax_object.add_progress_text) {
				progressText.text('');
			}
			if (vatParagraph.hasClass('validate-required')) {
				// Required
				vatParagraph.addClass('woocommerce-invalid');
			} else {
				// Not required
				vatParagraph.addClass('woocommerce-validated');
			}
			$('body').trigger('update_checkout');
		}
	};
});
